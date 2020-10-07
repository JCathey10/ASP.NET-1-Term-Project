using FootyFans.Models;
using FootyFans.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace FootyFans
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;

				options.Secure = CookieSecurePolicy.Always;
			});


			services.AddMvc();

			// Inject our repositories into our controllers
			services.AddTransient<IRepository, Repository>();

			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
				Configuration["ConnectionStrings:MsSqlConnection"]));

			services.AddIdentity<AppUser, IdentityRole>(opts =>
			{
				opts.User.RequireUniqueEmail = true;
				opts.Password.RequiredLength = 6;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
		{
			app.Use(async (ctx, next) =>
			{
				ctx.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
				ctx.Response.Headers.Add("X-XSS-Protection", "1");
				ctx.Response.Headers.Add("Cache-Control", "no-cache");
				await next();
			});

			app.UseStatusCodePages();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			// Enforce validation for MIME types, in other words... should not be changed
			app.Use(async (context, next) =>
			{
				context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
				await next();
			});

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			// Ensure that the database has been created and the latest migration applied
			context.Database.Migrate();

			// Add some data to the DB
			SeedData.Seed(context);

			AppDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
		}
	}
}
