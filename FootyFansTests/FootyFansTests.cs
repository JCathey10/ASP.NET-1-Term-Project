using System;
using System.Collections.Generic;
using FootyFans.Controllers;
using FootyFans.Models;
using FootyFans.Repositories;
using Xunit;

namespace FootyFansTests
{
	public class FootyFansTests
	{
		[Fact]
		public void FootageTest()
		{
			// Arrange
			var repo = new FakeRepository();
			var homeController = new HomeController(repo);

			// Act
			homeController.Footage();

			// Act
			Assert.Equal("Amazing skill moves from 2019", repo.Videos[0].Description);
			Assert.Equal("Ronaldinho's legendary skills", repo.Videos[1].Description);
			Assert.Equal("Leo Messi's career highlights", repo.Videos[2].Description);
			Assert.Equal("Cristiano Ronaldo Manchester United highlights", repo.Videos[3].Description);
		}

		[Fact]
		public void AddCommentTest()
		{
			// Arrange
			var repo = new FakeRepository();
			var homeController = new HomeController(repo);
			Video test = repo.GetVideoByDescription("Ronaldinho's legendary skills");

			// Act
			homeController.AddComment("Ronaldinho's legendary skills", "Did this test work?", "Josh");

			// Assert
			Assert.Equal("Did this test work?", test.Comments[1].CommentText.ToString());
		}

		[Fact]
		public void AddForumPostTest()
		{
			// Arrange
			var repo = new FakeRepository();
			var homeController = new HomeController(repo);
			ForumPost postTest = new ForumPost()
			{
				Subject = "Testing",
				Message = "This is a test"
			};

			//Act
			homeController.ForumPost(postTest);

			//Assert
			Assert.Equal(repo.ForumPosts[0], postTest);
		}

	}
}
