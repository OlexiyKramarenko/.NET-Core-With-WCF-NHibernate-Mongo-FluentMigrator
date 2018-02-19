using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.Presentation.MPA.Admin.Models.Articles;
using MShop.ViewComponents.Models;
using System;
using System.Collections.Generic;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, System.Guid>;

namespace MShop.Presentation.MPA.Admin.Controllers
{
	//[Authorize(Roles = "Administrators, Editors")]
	public class ManageArticlesController : Controller
	{
		private readonly IArticlesRepository _articlesRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ManageArticlesController(IArticlesRepository articlesRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_articlesRepository = articlesRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		#region Articles

		[HttpGet]
		public IActionResult ManageArticles(int pageIndex = 1, int pageSize = 5)
		{			
			int itemsCount = _articlesRepository.GetArticleCount();
			string controller = nameof(ManageArticlesController);
			string action = nameof(this.ManageArticles);
			var model = new PagerViewModel(itemsCount, pageSize, pageIndex, controller, action);
			return View(model);
		}

		[HttpGet]
		public IActionResult DeleteArticle(Guid id)
		{
			try
			{
				_articlesRepository.DeleteArticle(id);
				_unitOfWork.Commit();

				return RedirectToAction(nameof(this.ManageArticles));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddArticle()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddArticle(AddArticleViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var article = _mapper.Map<Article>(model);
					_articlesRepository.InsertArticle(article);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageArticles));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditArticle(Guid id)
		{
			try
			{
				Article article = _articlesRepository.GetArticleById(id);
				var model = _mapper.Map<EditArticleViewModel>(article);

				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		public IActionResult EditArticle(EditArticleViewModel model)
		{
			try
			{
				var article = _mapper.Map<Article>(model);
				_articlesRepository.UpdateArticle(article);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageArticles));

			}
			catch (Exception exc)
			{
				return View();
			}
		}

		#endregion

		#region Categories
		[HttpGet]
		public IActionResult ManageCategories()
		{
			try
			{
				IList<Category> categories = _articlesRepository.GetCategories();
				var model = _mapper.Map<IEnumerable<CategoryItemViewModel>>(categories);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeleteCategory(Guid id)
		{
			try
			{
				_articlesRepository.DeleteCategory(id);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageCategories));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCategory(AddCategoryViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var category = _mapper.Map<Category>(model);
					_articlesRepository.InsertCategory(category);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageCategories));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditCategory(Guid id)
		{
			try
			{
				Category category = _articlesRepository.GetCategoryById(id);
				var model = _mapper.Map<EditCategoryViewModel>(category);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPut]
		public IActionResult EditCategory(Guid id, EditCategoryViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var category = _mapper.Map<Category>(model);
					_articlesRepository.UpdateCategory(category);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageCategories));
			}
			catch
			{
				return View();
			}
		}
		#endregion

		#region Comments

		[HttpGet]
		public IActionResult ManageComments(int pageIndex, int pageSize)
		{
			try
			{
				IList<CommentProvider> comments = _articlesRepository.GetComments(pageIndex, pageSize);
				int itemsCount = _articlesRepository.GetCommentCount();
				string controller = nameof(ManageArticlesController);
				string action = nameof(this.ManageComments);
				var model = new ManageCommentsViewModel
				{
					CommentItems = _mapper.Map<IEnumerable<ManageCommentItemViewModel>>(comments),
					Pager = new PagerViewModel(itemsCount, pageSize, pageIndex, controller, action)
				};
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeleteComment(Guid id, int pageIndex, int pageSize)
		{
			try
			{
				_articlesRepository.DeleteComment(id);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageComments), new { pageIndex, pageSize });
			}
			catch (Exception e)
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditComment(Guid id)
		{
			try
			{
				Comment comment = _articlesRepository.GetCommentById(id);
				var model = _mapper.Map<EditCommentViewModel>(comment);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPut]
		public IActionResult EditComment(EditCommentViewModel model)
		{
			try
			{
				var comment = _mapper.Map<Comment>(model);
				_articlesRepository.UpdateComment(comment);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageComments));
			}
			catch
			{
				return View();
			}
		}

		#endregion

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}
