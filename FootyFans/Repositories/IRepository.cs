using System.Collections.Generic;
using FootyFans.Models;

namespace FootyFans.Repositories
{
	public interface IRepository
	{
		List<Video> Videos { get; }
		Video GetVideoByDescription(string description);
		AppUser GetUserByName(string name);
		List<AppUser> Users { get; }
		void AddUserProfile(AppUser userProfile);
		// Might need to add more...
	}
}
