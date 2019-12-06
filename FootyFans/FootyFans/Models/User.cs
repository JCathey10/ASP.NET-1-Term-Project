using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootyFans.Models
{
	public class User
	{
		private List<Comment> comments = new List<Comment>();
		public List<Comment> Comments { get { return comments; } }

		public int UserId { get; set; }
		public string Name { get; set; }
		public string FavoriteTeam { get; set; }
	}
}
