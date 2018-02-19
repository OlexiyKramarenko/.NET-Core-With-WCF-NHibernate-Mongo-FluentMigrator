using Microsoft.AspNetCore.Mvc;
using MShop.ViewComponents.Models;
using System.Threading.Tasks;

namespace MShop.ViewComponents.Components
{
	public class PagerViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(PagerViewModel Pager)
		{
			return View(Pager);
		}
	}
}
