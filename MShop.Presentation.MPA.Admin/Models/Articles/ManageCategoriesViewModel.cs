using MShop.ViewComponents.Models;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Admin.Models.Articles
{
	public class ManageCategoriesViewModel
	{
		public PagerViewModel Pager { get; set; }
		public IEnumerable<CategoryItemViewModel> CategoryItems { get; set; }
	}
}
