using AutoMapper;
using MShop.DataLayer.EF.Providers.Articles;
using MShop.ViewComponents.Models;

namespace MShop.ViewComponents.Infrastructure
{
	public class ArticleProfile : Profile
	{
		public ArticleProfile()
		{
			CreateMap<ArticleProvider, ArticleItemViewModel>()
				.ForMember(a => a.Location, p => p.ResolveUsing(provider =>
				{
					if (!string.IsNullOrEmpty(provider.Country) && !string.IsNullOrEmpty(provider.City))
						return provider.Country + ", " + provider.City;

					return string.Empty;
				}));

		}
	}
}
