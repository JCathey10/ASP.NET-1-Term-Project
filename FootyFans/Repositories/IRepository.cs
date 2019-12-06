using System.Collections.Generic;
using FootyFans.Models;

namespace FootyFans.Repositories
{
	public interface IRepository
	{
		List<Video> Videos { get; }
		Video GetVideoByDescription(string description);
		// Might need to add more...
	}
}
