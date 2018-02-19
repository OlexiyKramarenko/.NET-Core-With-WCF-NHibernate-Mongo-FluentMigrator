using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.EF.Entities.Store; 
using MShop.Presentation.MPA.Public.Models.Store;
using System;
using System.Collections.Generic;
using IStoreRepository = MShop.DataLayer.Repositories.IStoreRepository<
	MShop.DataLayer.EF.Entities.Store.Department,
	MShop.DataLayer.EF.Entities.Store.OrderStatus,
	MShop.DataLayer.EF.Entities.Store.ShippingMethod,
	MShop.DataLayer.EF.Entities.Store.Product,
	MShop.DataLayer.EF.Entities.Store.Order,
	MShop.DataLayer.EF.Entities.Store.OrderItem,
	MShop.DataLayer.EF.Providers.Store.OrderProvider,
	MShop.DataLayer.Providers.Store.ProductProvider, System.Guid>;

namespace MShop.Presentation.MPA.Public.Components
{
	public class OrderSummaryViewComponent : ViewComponent
	{
		private readonly IStoreRepository _storeRepository;
		private readonly IMapper _mapper;

		public OrderSummaryViewComponent(IStoreRepository storeRepository, IMapper mapper)
		{
			_storeRepository = storeRepository;
			_mapper = mapper;
		}
		public IViewComponentResult Invoke(Guid id)
		{
			List<OrderItem> items = _storeRepository.GetOrderItems(id);
			List<OrderItemViewModel> model = _mapper.Map<List<OrderItem>, List<OrderItemViewModel>>(items);
			return View(model);
		}
	}
}
