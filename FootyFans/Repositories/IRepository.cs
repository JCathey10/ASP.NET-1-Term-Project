using System.Collections.Generic;
using FootyFans.Models;

namespace FootyFans.Repositories
{
	public interface IRepository
	{
		List<Video> Videos { get; }
		Video GetVideoByDescription(string description);
		User GetUserByName(string name);
		List<User> Users { get; }
		void AddUserProfile(User userProfile);
		// Might need to add more...
	}
}
