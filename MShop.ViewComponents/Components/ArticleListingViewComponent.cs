using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.ViewComponents.Models;
using System;
using System.Collections.Generic;
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

		public IViewComponentResult Invoke(Guid categoryId, int pageIndex, int pageSize)
		{
			IList<ArticleProvider> articles = null;
			if (categoryId != Guid.Empty)
			{
				articles = _articlesRepository.GetArticles(categoryId, pageIndex, pageSize);
			}
			else
			{
				articles = _articlesRepository.GetArticles(pageIndex, pageSize);
			}

			var model = new ArticleListingViewModel
			{
				Articles = _mapper.Map<IEnumerable<ArticleItemViewModel>>(articles),
				Categories = new SelectList(_articlesRepository.GetCategories(),
				nameof(Category.Id), nameof(Category.Title))
			};

			return View(model);
		}
	}
}
