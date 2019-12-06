using System.Collections.Generic;
using FootyFans.Models;

namespace FootyFans.Repositories
{
	public interface IRepository
	{
		List<Video> Videos { get; }
		// Might need to add more...
	}
}
