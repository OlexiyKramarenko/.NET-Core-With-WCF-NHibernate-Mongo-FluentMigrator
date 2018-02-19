using AutoMapper; 
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Providers.Articles; 
using MShop.Presentation.MPA.Public.Models.Articles;
using System;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, 
System.Guid>;

namespace MShop.Presentation.MPA.Public.Components
{
	public class ArticleBoxViewComponent : ViewComponent
	{
		private readonly IArticlesRepository _repository;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public ArticleBoxViewComponent(IUnitOfWork unitOfWork, IArticlesRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public IViewComponentResult Invoke(Guid articleId)
		{
			ArticleProvider article = _repository.GetArticleById(articleId);
			_repository.IncrementArticleViewCount(article.Id);
			_unitOfWork.Commit();
			ArticleBoxViewModel model = _mapper.Map<ArticleProvider, ArticleBoxViewModel>(article);
			return View(model);
		}
	}
}
