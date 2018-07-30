using System;
using System.Collections.Generic; 

namespace MShop.Presentation.MPA.Public.Models.Forums
{
	public class ShowThreadViewModel
	{
		public Guid ForumId { get; set; }
		public Guid ThreadId { get; set; } 
		public IEnumerable<PostItemViewModel> Posts { get; set; }
	}
}
