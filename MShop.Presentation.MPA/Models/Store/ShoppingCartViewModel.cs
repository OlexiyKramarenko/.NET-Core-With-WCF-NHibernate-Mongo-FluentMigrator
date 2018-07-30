using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Models.Store
{
	public class ShoppingCartViewModel
	{
		//public string ShippingMethod { get; set; }
		//public decimal ShippingMethodPrice { get; set; }
		//public IEnumerable<SelectListItem> ShippingMethods { get; set; }
		public IEnumerable<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
	}
}
