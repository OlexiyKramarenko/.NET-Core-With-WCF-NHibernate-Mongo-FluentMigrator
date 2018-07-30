using MShop.ViewComponents.Models;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Admin.Models.Store
{
    public class ManageProductsViewModel
    {
		public PagerViewModel Pager { get; set; }
		public IEnumerable<ManageOrderItemViewModel> ProductItems { get; set; }
	}
}
