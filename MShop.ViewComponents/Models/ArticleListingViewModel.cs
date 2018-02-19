
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MShop.ViewComponents.Models
{
	public class ArticleListingViewModel
	{
		public IEnumerable<ArticleItemViewModel> Articles { get; set; }
		public SelectList Categories { get; set; }
		public Guid CategoryId { get; set; }
	}
}
