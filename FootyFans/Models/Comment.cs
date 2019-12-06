using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootyFans.Models
{
	public class Comment
	{
		public int CommentId { get; set; }
		public User UserName { get; set; }
		public string CommentText { get; set; }
	}
}
