using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootyFans.Models;
using Microsoft.EntityFrameworkCore;

namespace FootyFans.Repositories
{
	public class Repository : IRepository
	{
		private AppDbContext context;
		public List<Video> Videos { get { return context.Videos.Include("Comments").ToList(); } }
		public List<ForumPost> ForumPosts { get { return context.ForumPosts.ToList(); } }

		public Repository(AppDbContext appDbContext)
		{
			context = appDbContext;
		}

		public Video GetVideoByDescription(string description)
		{
			Video video = context.Videos.First(v => v.Description == description);
			return video;
		}

		public void AddComment(Video video, Comment comment)
		{
			if (comment != null & video != null)
			{
				video.Comments.Add(comment);
				context.Videos.Update(video);
				context.SaveChanges();
			}
		}

		public void AddForumPost(ForumPost newPost)
		{
			if (newPost != null)
			{
				context.ForumPosts.Add(newPost);
				context.SaveChanges();
			}
		}

		public ForumPost GetForumPostBySubject(string subject)
		{
			ForumPost post = context.ForumPosts.FirstOrDefault(f => f.Subject == subject);
			return post;
		}
	}
}
