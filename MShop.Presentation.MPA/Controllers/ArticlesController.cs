using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Providers.Articles;
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
		private IHttpContextAccessor _accessor;

		public ArticlesController(IHttpContextAccessor accessor, IArticlesRepository articlesRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_accessor = accessor;
			_articlesRepository = articlesRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult BrowseArticles(Guid categoryId, int pageIndex, int pageSize)
		{
			var model = new BrowseArticlesViewModel
			{
				CategoryId = categoryId,
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			return View(model);
		}

		[HttpGet]
		public IActionResult ShowArticle(Guid id)
		{
			Article article = _articlesRepository.GetArticleById(id);
			IEnumerable<CommentProvider> comments = _articlesRepository.GetComments(id, 1, 5);
			var model = new ShowArticleViewModel
			{
				Text = article.Body,
				Title = article.Title,
				Comments = _mapper.Map<List<CommentItemViewModel>>(comments)
			};
			return View(model);
		}
		
		[HttpGet]
		public IActionResult ShowCategories()
		{
			try
			{
				IList<Category> categories = _articlesRepository.GetCategories();
				var model = _mapper.Map<List<CategoryItemViewModel>>(categories);
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
			var comment = _mapper.Map<Comment>(model);
			comment.AddedDate = DateTime.Now;
			comment.AddedByIp = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
			_articlesRepository.InsertComment(comment);
			_unitOfWork.Commit();
			return RedirectToAction(nameof(this.ShowArticle), new { id = model.ArticleId });
		}
	}
}
