using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootyFans.Models
{
	public class ForumPost
	{
		public int ForumPostID { get; set; }

		private List<Comment> comments = new List<Comment>();
		public List<Comment> Comments { get { return comments; } }

		[Required]
		public string Subject { get; set; }

		[Required]
		public string Message { get; set; }
	}
}
