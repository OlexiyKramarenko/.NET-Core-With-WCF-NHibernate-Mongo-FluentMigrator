using AutoMapper;
using MShop.DataLayer.Providers.Store;

namespace MShop.ViewComponents.Infrastructure
{
	public class StoreProfile : Profile
	{
		public StoreProfile()
		{
			CreateMap<ProductProvider, Models.ProductItemViewModel>();			
		}
	}
}
