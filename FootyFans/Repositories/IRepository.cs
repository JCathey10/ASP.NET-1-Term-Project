using System.Collections.Generic;
using FootyFans.Models;

namespace FootyFans.Repositories
{
	public interface IRepository
	{
		List<Video> Videos { get; }
		List<ForumPost> ForumPosts { get; }
		Video GetVideoByDescription(string description);

		void AddComment(Video video, Comment comment);
		void AddForumPost(ForumPost newPost);
		ForumPost GetForumPostBySubject(string subject);
	}
}
