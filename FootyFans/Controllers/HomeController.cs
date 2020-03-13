using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FootyFans.Models;
using FootyFans.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FootyFans.Controllers
{
	public class HomeController : Controller
	{
		IRepository repo;
		private UserManager<AppUser> userManager;

		public HomeController(IRepository r, UserManager<AppUser> userMgr)
		{
			repo = r;
			userManager = userMgr;
		}

		public IActionResult Index() => View();

		public IActionResult Home() => View(userManager.Users);
		

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Footage()
		{
			List<Video> videos = repo.Videos;

			return View(videos);
		}

		public IActionResult News()
		{
			return View();
		}

		//public IActionResult CreateProfile()
		//{
		//	return View();
		//}

		//[HttpPost]
		//public IActionResult CreateProfile(AppUser userProfile)
		//{
		//	// Get the list of current profiles from the repo
		//	List<AppUser> profiles = repo.Users;

		//	// Add the new profile to the list
		//	profiles.Add(userProfile);

		//	return View("Index", profiles);
		//}

		//public IActionResult ProfilePage(string name)
		//{
		//	User user = repo.GetUserByName(name);
		//	return View(user);
		//}

		public IActionResult AddComment(string description)
		{
			return View("AddComment", HttpUtility.HtmlDecode(description));
		}

		[HttpPost]
		public RedirectToActionResult AddComment(string description, string commentText, string name)
		{
			Video video = repo.GetVideoByDescription(description);

			video.Comments.Add(new Comment()
			{
				Name = name,
				CommentText = commentText
			});
			return RedirectToAction("Footage");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
