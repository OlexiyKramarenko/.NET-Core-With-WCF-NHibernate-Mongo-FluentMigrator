using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.ViewComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, System.Guid>;

namespace MShop.ViewComponents.Components
{
	public class ArticleListingViewComponent : ViewComponent
	{
		private readonly IArticlesRepository _articlesRepository;
		private readonly IMapper _mapper;

		public ArticleListingViewComponent(IArticlesRepository articlesRepository, IMapper mapper)
		{
			_articlesRepository = articlesRepository;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke(int pageIndex, int pageSize)
		{
			var model = new ArticleListingViewModel();
			IList<ArticleProvider> articles = _articlesRepository.GetArticles(pageIndex, pageSize);
			model.Articles = _mapper.Map<IEnumerable<ArticleItemViewModel>>(articles);
			model.Categories = new SelectList(
				_articlesRepository.GetCategories()
								   .Select(a => new SelectListItem
								   {
									   Value = Convert.ToString(a.Id),
									   Text = a.Title
								   })
								   .ToList(), "Value", "Text");
			return View(model);
		}
	}
}
