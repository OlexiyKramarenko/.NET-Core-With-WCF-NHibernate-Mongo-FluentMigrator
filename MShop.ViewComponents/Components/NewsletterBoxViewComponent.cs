using Microsoft.AspNetCore.Mvc;

namespace MShop.ViewComponents.Components
{
	public class NewsletterBoxViewComponent : ViewComponent
	{
		public NewsletterBoxViewComponent()
		{
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
