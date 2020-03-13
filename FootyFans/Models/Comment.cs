using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootyFans.Models
{
	public class Comment
	{
		
		public int CommentId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string CommentText { get; set; }
	}
}
