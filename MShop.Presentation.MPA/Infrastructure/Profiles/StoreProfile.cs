using AutoMapper;
using MShop.DataLayer.EF.Entities.Store;
using MShop.Presentation.MPA.Public.Models.Store;

namespace MShop.Presentation.MPA.Public.Infrastructure.Profiles
{
	public class StoreProfile : Profile
	{
		public StoreProfile()
		{
			CreateMap<ShippingMethod, ShippingMethodItemViewModel>()
				.ForMember(a => a.Text, p => p.ResolveUsing(a =>
			{
				if (!string.IsNullOrEmpty(a.Title) && a.Price != 0)
					return a.Title + " " + a.Price + " USD";

				return string.Empty;
			}));
			CreateMap<Product, ShowProductViewModel>();
		}
	}
}
