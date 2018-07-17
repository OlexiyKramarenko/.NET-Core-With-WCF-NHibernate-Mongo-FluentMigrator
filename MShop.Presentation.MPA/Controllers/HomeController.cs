using Microsoft.AspNetCore.Mvc;
using MShop.Presentation.MPA.Public.Models.Home;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, System.Guid>;

namespace MShop.Presentation.MPA.Public.Controllers
{
	public class HomeController : Controller
	{
		private readonly IArticlesRepository repo;
		public HomeController(IArticlesRepository repo)
		{
			this.repo = repo;
		}

		public IActionResult Index()
		{
			int count = repo.GetArticleCount();
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}
        [HttpPost]
		public IActionResult Contact(ContactsViewModel model)
		{
			return View();
		}
		public IActionResult Error()
		{
			return View();
		}
	}
}
