using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootyFans.Models;

namespace FootyFans.Repositories
{
	public class FakeRepository : IRepository
	{
		private static List<Video> videos = new List<Video>();
		public List<Video> Videos { get { return videos; } }

		private static List<User> users = new List<User>();
		public List<User> Users { get { return users; } }

		static FakeRepository()
		{
			AddTestData();
			AddTestUserProfiles();
		}

		public Video GetVideoByDescription(string description)
		{
			Video video = videos.Find(v => v.Description == description);
			return video;
		}
		public User GetUserByName(string name)
		{
			User user = users.Find(u => u.Name == name);
			return user;
		}

		public void AddUserProfile(User userProfile)
		{
			users.Add(userProfile);
		}

		static void AddTestData()
		{
			Video skills2019 = new Video()
			{
				VideoUrl = "../videos/Skills2019.mp4",
				Description = "Amazing skill moves from 2019"
			};
			Comment skillsComment = new Comment()
			{
				CommentText = "Love these skills!"
			};
			skills2019.Comments.Add(skillsComment);
			videos.Add(skills2019);

			Video ronaldinhoSkills = new Video()
			{
				VideoUrl = "../videos/RonaldinhoSkills.mp4",
				Description = "Ronaldinho's legendary skills"
			};
			Comment ronaldinhoComment = new Comment() { CommentText = "I wish Ronaldinho was still playing." };
			ronaldinhoSkills.Comments.Add(ronaldinhoComment);
			videos.Add(ronaldinhoSkills);

			Video messiSkills = new Video()
			{
				VideoUrl = "../videos/MessiSkills.mp4",
				Description = "Leo Messi's career highlights"
			};
			Comment messiComment = new Comment() { CommentText = "He's the greatest player every!" };
			messiSkills.Comments.Add(messiComment);
			videos.Add(messiSkills);

			Video ronaldoSkills = new Video()
			{
				VideoUrl = "../videos/RonaldoSkills.mp4",
				Description = "Cristiano Ronaldo Manchester United highlights"
			};
			Comment ronaldoComment = new Comment() { CommentText = "Ronaldo has always been one of the greatest players ever." };
			ronaldoSkills.Comments.Add(ronaldoComment);
			videos.Add(ronaldoSkills);
		}

		static void AddTestUserProfiles()
		{
			User user1 = new User()
			{
				Name = "Josh Cathey",
				FavoriteTeam = "Portand Timbers and FC Barcelona",
				About = "Hello! I love this sport (except for all the ridiculous flopping)! " +
						"I've been playing soccer since I was 6 and I'm hoping to play for the rest of my life!"
			};
			users.Add(user1);

			User user2 = new User()
			{
				Name = "John Doe",
				FavoriteTeam = "Portand Timbers",
				About = "I've never played soccer, but I love watching the Timbers!"
			};
			users.Add(user2);
		}
	}
}
