using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.Presentation.MPA.Public.Models.Articles;
using System.Collections.Generic;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, System.Guid>;

namespace MShop.Presentation.MPA.Public.Components
{
	public class CommentsViewComponent : ViewComponent
	{
		private readonly IArticlesRepository _repository;
		private readonly IMapper _mapper;
		public CommentsViewComponent(IArticlesRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke(int pageIndex, int pageSize)
		{
			IList<CommentProvider> comments = _repository.GetComments(pageIndex,
				pageSize);
			IList<CommentItemViewModel> model = _mapper.Map<List<CommentItemViewModel>>(comments);
			return View(model);
		}
	}
}
