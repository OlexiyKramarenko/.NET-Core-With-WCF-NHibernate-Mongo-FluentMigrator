using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.Providers.Store;
using MShop.ViewComponents.Models;
using IStoreRepository = MShop.DataLayer.Repositories.IStoreRepository<
	MShop.DataLayer.EF.Entities.Store.Department,
	MShop.DataLayer.EF.Entities.Store.OrderStatus,
	MShop.DataLayer.EF.Entities.Store.ShippingMethod,
	MShop.DataLayer.EF.Entities.Store.Product,
	MShop.DataLayer.EF.Entities.Store.Order,
	MShop.DataLayer.EF.Entities.Store.OrderItem,
	MShop.DataLayer.EF.Providers.Store.OrderProvider,
	MShop.DataLayer.Providers.Store.ProductProvider, System.Guid>;

namespace MShop.ViewComponents.Components.Store
{
	public class ProductListingViewComponent : ViewComponent
	{
		private readonly IStoreRepository _storeRepository;
		private readonly IMapper _mapper;

		public ProductListingViewComponent(IStoreRepository storeRepository, IMapper mapper)
		{
			_storeRepository = storeRepository;
			_mapper = mapper;
		}
		
		public async Task<IViewComponentResult> InvokeAsync(int pageIndex, int pageSize)
		{
			Expression<Func<ProductProvider, dynamic>> expression = p => p.Title;
			IEnumerable<ProductProvider> products = _storeRepository.GetProducts(expression, pageIndex, pageSize);
			var model = _mapper.Map<IEnumerable<ProductItemViewModel>>(products);
			ViewBag.IsAdmin = true;
			return View(model);
		}
	}
}
