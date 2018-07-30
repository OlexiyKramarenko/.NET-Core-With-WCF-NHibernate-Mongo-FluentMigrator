using System;

namespace MShop.Presentation.MPA.Public.Models.Articles
{
	public class BrowseArticlesViewModel
	{
		public Guid CategoryId { get; set; }
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
	}
}
