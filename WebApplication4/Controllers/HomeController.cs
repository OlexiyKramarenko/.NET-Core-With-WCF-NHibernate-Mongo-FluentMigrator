
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MShop.Search;
using MShop.Search.Elastic;


using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider,string>;

namespace WebApplication4.Controllers
{
	//POCO класс
	public class City
	{
		public City(int id, string name, string state, string country, string population)
		{
			ID = id;
			Name = name;
			State = state;
			Country = country;
			Population = population;
		}

		public int ID { get; set; }
		public string Name { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string Population { get; set; }
	}

	public class HomeController : Controller
	{
		IArticlesRepository _repo;
		public HomeController(IArticlesRepository repo)
		{
			_repo = repo;
		}

		public void AddNewIndexTest()
		{
			ISearchService service = new ElasticService();
			service.AddNewIndex(new City(1, "delhi", "delhi", "India", "9.879 million"));
			service.AddNewIndex(new City(2, "mumbai", "Maharashtra", "India", "11.98 million"));
			service.AddNewIndex(new City(3, "chenai", "Tamil Nadu", "India", "4.334 million"));
			service.AddNewIndex(new City(4, "kolkata", "W. Bengal", "India", "4.573 million"));
			service.AddNewIndex(new City(4, "Banglore", "Karnataka", "India", "4.302 million"));
			service.AddNewIndex(new City(4, "Pune", "Maharashtra", "India", "2.538 million"));
		}

		public IActionResult Index()
		{
			ISearchService searchService = new ElasticService();
			AddNewIndexTest();
			List<City> result = searchService.GetAll<City>();
			List<City> list = searchService.SearchInAllFields<City>("India", 0, 10);
			List<City> list2 = searchService.SearchInSingleField<City>(nameof(City.Name), "mumbai", 0, 10);
			return View();
		}
	}
}
