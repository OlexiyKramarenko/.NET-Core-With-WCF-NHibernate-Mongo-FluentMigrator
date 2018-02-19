using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Models.Forums
{
	public class BrowseThreadsViewModel
	{
		public Guid ForumId { get; set; }
		public List<ThreadItemViewModel> ThreadItems { get; set; }
		public SelectList Forums { get; set; }
	}
}
