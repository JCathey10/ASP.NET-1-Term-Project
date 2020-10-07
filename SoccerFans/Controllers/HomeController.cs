using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FootyFans.Models;
using FootyFans.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

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
			List<ForumPost> posts = repo.ForumPosts;
			return View(posts);
		}
			

		public IActionResult Home()
		{
			List<ForumPost> posts = repo.ForumPosts;
			return View(posts);
		}


		public IActionResult About()
		{
			List<ForumPost> posts = repo.ForumPosts;
			return View(posts);
		}

		public IActionResult Footage()
		{
			List<Video> videos = repo.Videos;

			return View(videos);
		}

		public IActionResult News()
		{
			List<ForumPost> posts = repo.ForumPosts;
			return View(posts);
		}

		public IActionResult AddComment(string description)
		{
			return View("AddComment", HttpUtility.HtmlDecode(description));
		}


		[Authorize]
		[HttpPost]
		public RedirectToActionResult AddComment(string description, string commentText, string name)
		{
			Video video = repo.GetVideoByDescription(description);
			Comment comment = (new Comment()
			{
				Name = name,
				CommentText = commentText
			});
			repo.AddComment(video, comment);

			return RedirectToAction("Footage");
		}

		public IActionResult Forum(string subject)
		{
			ForumPost post = repo.GetForumPostBySubject(subject);
			return View(post);
		}


		public IActionResult ForumPost()
		{
			return View();
		}

		[HttpPost]
		public RedirectToActionResult ForumPost(ForumPost newPost)
		{
			if (ModelState.IsValid)
			{
				repo.AddForumPost(newPost);
			}
			return RedirectToAction("Home");
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
