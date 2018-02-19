using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.EF.Entities.Articles.Article,
MShop.DataLayer.EF.Entities.Articles.Category,
MShop.DataLayer.EF.Entities.Articles.Comment,
MShop.DataLayer.EF.Providers.Articles.ArticleProvider,
MShop.DataLayer.EF.Providers.Articles.CommentProvider, System.Guid>;

namespace MShop.Presentation.MPA.Public.Components
{
    public class CommentDetailsViewComponent : ViewComponent
	{
		private readonly IArticlesRepository _repository;
		private readonly IMapper _mapper;
		public CommentDetailsViewComponent(IArticlesRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		 
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
