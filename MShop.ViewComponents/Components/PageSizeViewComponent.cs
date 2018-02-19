using Microsoft.AspNetCore.Mvc;
using MShop.ViewComponents.Models;

namespace MShop.ViewComponents.Components
{
	public class PageSizeViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(PageSizeViewModel model)
		{ 
			return View(model);
		}
	}
}
