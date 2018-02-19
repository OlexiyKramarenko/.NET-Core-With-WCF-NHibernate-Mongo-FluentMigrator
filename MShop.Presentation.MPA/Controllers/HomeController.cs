using Microsoft.AspNetCore.Mvc;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, string>;

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
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
