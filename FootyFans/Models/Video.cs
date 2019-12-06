using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootyFans.Models
{
	public class Video
	{
		private List<Comment> comments = new List<Comment>();
		public List<Comment> Comments { get { return comments; } }

		public int VideoID { get; set; }
		public string VideoUrl { get; set; }
		public string Description { get; set; }
	}
}
