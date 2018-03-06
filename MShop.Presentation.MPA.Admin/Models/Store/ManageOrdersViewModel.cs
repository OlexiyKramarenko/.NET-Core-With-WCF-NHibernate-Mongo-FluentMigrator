
using System.Collections.Generic;
using MShop.ViewComponents.Models;

namespace MShop.Presentation.MPA.Admin.Models.Store
{
    public class ManageOrdersViewModel
    {
		public PagerViewModel Pager { get; set; }
		public IEnumerable<ManageOrderItemViewModel> OrderItems { get; set; }		
	}
}
