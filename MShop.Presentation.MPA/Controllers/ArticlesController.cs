using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.Presentation.MPA.Public.Models.Articles;
using System;
using System.Collections.Generic;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider,
System.Guid>;


namespace MShop.Presentation.MPA.Public.Controllers
{
	public class ArticlesController : Controller
	{
		private readonly IArticlesRepository _articlesRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ArticlesController(IArticlesRepository articlesRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_articlesRepository = articlesRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ShowArticle(Guid articleId)
		{
			return View();
		}

		[HttpGet]
		public IActionResult RateArticle(Guid articleId, int rating)
		{
			try
			{
				_articlesRepository.RateArticle(articleId, rating);
				_unitOfWork.Commit();
				return View("_RateArticle");
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult ShowCategories()
		{
			try
			{
				IList<Category> categories = _articlesRepository.GetCategories();
				List<CategoryItemViewModel> model = _mapper.Map<IList<Category>, List<CategoryItemViewModel>>(categories);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		public IActionResult LeaveComment(CommentDetailsViewModel model)
		{
			//
			return RedirectToAction(nameof(this.ShowCategories));
		}
	}
}
