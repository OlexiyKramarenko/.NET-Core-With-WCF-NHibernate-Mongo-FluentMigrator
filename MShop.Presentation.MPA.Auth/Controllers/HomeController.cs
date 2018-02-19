using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.EF.Repositories;
using MShop.Presentation.MPA.Auth.Models;

namespace MShop.Presentation.MPA.Auth.Controllers
{
	public class HomeController : Controller
	{
		ArticlesRepository repo;
		public HomeController(ArticlesRepository repo)
		{
			this.repo = repo;
		}

		public IActionResult Index()
		{
			int count = repo.GetArticleCount();
			return View();
		}
	

	}
}
