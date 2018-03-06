using Microsoft.AspNetCore.Mvc;
using MShop.ViewComponents.Models;

namespace MShop.ViewComponents.Components
{
	public class PagerViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(PagerViewModel Pager)
		{
			return View(Pager);
		}
	}
}
