using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FootyFans.Models;
using FootyFans.Repositories;

namespace FootyFans.Controllers
{
	public class HomeController : Controller
	{
		IRepository repo;
		public HomeController(IRepository r)
		{
			repo = r;
		}

		public IActionResult Index()
		{
			return View();
		}

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

		public IActionResult AddComment(string description)
		{
			return View("AddComment", HttpUtility.HtmlDecode(description));
		}

		[HttpPost]
		public RedirectToActionResult AddComment(string description, string commentText, string user)
		{
			Video video = repo.GetVideoByDescription(description);
			video.Comments.Add(new Comment()
			{
				UserName = new User() { Name = user },
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
