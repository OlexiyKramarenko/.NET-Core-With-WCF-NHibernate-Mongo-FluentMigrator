using AutoMapper;
using DAL.Providers.Articles;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.Repositories;
using MShop.ViewComponents.Models;
using System.Collections.Generic;

namespace MShop.ViewComponents.Controllers
{
	public class ArticleListingController : Controller
	{
		private readonly IArticlesRepository _repository;
		private readonly IMapper _mapper;

		public ArticleListingController(IArticlesRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		 
		//public IViewComponentResult Invoke(int pageIndex, int pageSize)
		//{
		//	List<ArticleProvider> articles = _repository.GetArticles(pageIndex, pageSize);

		//	List<ArticleItemViewModel> model = _mapper.Map<List<ArticleProvider>, List<ArticleItemViewModel>>(articles);

		//	return View(model);
		//}
	}
}
