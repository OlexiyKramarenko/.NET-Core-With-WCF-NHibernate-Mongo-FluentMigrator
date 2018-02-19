
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MShop.Presentation.MPA.Admin.Models.Forums
{
	public class MoveThreadViewModel
	{
		public Guid ThreadPostId { get; set; }
		public Guid ForumId { get; set; }
		public string ThreadTitle { get; set; }
		public string ForumTitle { get; set; }
		public List<SelectListItem> Forums { get; set; }
		public Guid ForumTitleId { get; set; }
	}
}
