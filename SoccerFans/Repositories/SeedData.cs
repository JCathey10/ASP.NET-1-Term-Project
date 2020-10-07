using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using FootyFans.Models;

namespace FootyFans.Repositories
{
	public class SeedData
	{

		public static void Seed(AppDbContext context)
		{
			if (!context.Videos.Any())
			{
				Video skills2019 = new Video()
				{
					VideoUrl = "../videos/Skills2019.mp4",
					Description = "Amazing skill moves from 2019",
				};
				Comment skillsComment = new Comment()
				{
					Name = "Josh",
					CommentText = "Love these skills!"
				};
				skills2019.Comments.Add(skillsComment);
				context.Videos.Add(skills2019);

				Video ronaldinhoSkills = new Video()
				{
					VideoUrl = "../videos/RonaldinhoSkills.mp4",
					Description = "Ronaldinho's legendary skills",
				};
				Comment ronaldinhoComment = new Comment() 
				{ 
					Name = "Josh", 
					CommentText = "I wish Ronaldinho was still playing." 
				};
				ronaldinhoSkills.Comments.Add(ronaldinhoComment);
				context.Videos.Add(ronaldinhoSkills);

				Video messiSkills = new Video()
				{
					VideoUrl = "../videos/MessiSkills.mp4",
					Description = "Leo Messi's career highlights"
				};
				Comment messiComment = new Comment() 
				{ 
					Name = "Josh", 
					CommentText = "He's the greatest player every!" 
				};
				messiSkills.Comments.Add(messiComment);
				context.Videos.Add(messiSkills);

				Video ronaldoSkills = new Video()
				{
					VideoUrl = "../videos/RonaldoSkills.mp4",
					Description = "Cristiano Ronaldo career highlights"
				};
				Comment ronaldoComment = new Comment() 
				{ 
					Name = "Josh",
					CommentText = "Ronaldo has always been one of the greatest players ever." 
				};
				ronaldoSkills.Comments.Add(ronaldoComment);
				context.Videos.Add(ronaldoSkills);


				// Forums 
				ForumPost post1 = new ForumPost()
				{
					Subject = "Break In Action",
					Message = "I can't wait until the Coronavirus outbreak is over " +
								"so we can go back to watching sports!",
				};
				context.ForumPosts.Add(post1);

				// Save all the data
				context.SaveChanges();

			}
		}
	}
}
