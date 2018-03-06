using AutoMapper;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Providers.Store;
using MShop.DataLayer.Providers.Store;
using MShop.Presentation.MPA.Admin.Models.Store;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Admin.Infrastructure.Profiles
{
	public class StoreProfile : Profile
	{
		public StoreProfile()
		{
			CreateMap<ProductProvider, MShop.ViewComponents.Models.ProductItemViewModel>();
			CreateMap<ProductProvider, AddProductViewModel>();
			CreateMap<AddProductViewModel, DataLayer.EF.Entities.Store.Product>();
			CreateMap<DataLayer.EF.Entities.Store.Product, EditProductViewModel>();
			CreateMap<AddProductViewModel, DataLayer.EF.Entities.Store.Product>();
			CreateMap<AddShippingMethodViewModel,ShippingMethod>();
			CreateMap<EditShippingMethodViewModel, ShippingMethod>().ReverseMap();
			CreateMap<ShippingMethod, ShippingMethodViewModel>();
			CreateMap<ShippingMethod, ManageShippingMethodItemViewModel>();
			CreateMap<EditShippingMethodViewModel, ShippingMethod>();
			CreateMap<Department, DepartmentItemViewModel>();
			CreateMap<AddDepartmentViewModel, Department>();
			CreateMap<Department, EditDepartmentViewModel>().ReverseMap();
			CreateMap<OrderProvider, ManageOrderItemViewModel>()
				.ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
			CreateMap<OrderItem, ManageOrderedItemViewModel>();
			CreateMap<List<OrderItem>,List< OrderItemViewModel>>();
			CreateMap<Order, EditOrderViewModel>()
				.ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
				.ReverseMap();

			CreateMap<OrderProvider, Models.Store.OrderItemViewModel>();
			CreateMap<OrderStatus, EditOrderStatusViewModel>();
			CreateMap<EditOrderViewModel, Order>().ReverseMap();
			CreateMap<OrderStatus, OrderStatusItemViewModel>();
			CreateMap<OrderStatus, EditOrderStatusViewModel>();
			CreateMap<EditOrderStatusViewModel, OrderStatus>();
			CreateMap<AddOrderStatusViewModel, OrderStatus>();
		}
	}
}
