using AutoMapper;
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.Presentation.MPA.Public.Models.Articles;
using MShop.ViewComponents.Models;

namespace MShop.Presentation.MPA.Public.Infrastructure.Profiles
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
			CreateMap<ArticleProvider, ArticleItemViewModel>()
				   .ForMember(a => a.Location, p => p.ResolveUsing(provider =>
				   {
					   if (!string.IsNullOrEmpty(provider.Country) && !string.IsNullOrEmpty(provider.City))
						   return provider.Country + ", " + provider.City;

					   return string.Empty;
				   }));
			CreateMap<Category, CategoryItemViewModel>();
			CreateMap<CommentProvider, CommentItemViewModel>();
        }
    }
}
