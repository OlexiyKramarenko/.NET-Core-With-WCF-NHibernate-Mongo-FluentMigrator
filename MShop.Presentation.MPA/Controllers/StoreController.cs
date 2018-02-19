using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Providers.Store;
using MShop.DataLayer.Providers.Store;
using MShop.Presentation.MPA.Public.Models.Store;
using IStoreRepository = MShop.DataLayer.Repositories.IStoreRepository<
	MShop.DataLayer.EF.Entities.Store.Department,
	MShop.DataLayer.EF.Entities.Store.OrderStatus,
	MShop.DataLayer.EF.Entities.Store.ShippingMethod,
	MShop.DataLayer.EF.Entities.Store.Product,
	MShop.DataLayer.EF.Entities.Store.Order,
	MShop.DataLayer.EF.Entities.Store.OrderItem,
	MShop.DataLayer.EF.Providers.Store.OrderProvider,
	MShop.DataLayer.Providers.Store.ProductProvider, System.Guid>;

namespace MShop.Presentation.MPA.Public.Controllers
{
	public class StoreController : Controller
	{
		private readonly IStoreRepository _storeRepository;
		private readonly IUnitOfWork _unitOfWOrk;
		private readonly IMapper _mapper;

		public StoreController(IStoreRepository storeRepository, IUnitOfWork unitOfWOrk, IMapper mapper)
		{
			_storeRepository = storeRepository;
			_unitOfWOrk = unitOfWOrk;
			_mapper = mapper;
		}



		[HttpGet]
		public IActionResult ShippingDetails(Guid id)
		{
			ShippingMethod shippingMethod = _storeRepository.GetShippingMethodById(id);
			ShippingDetailsViewModel model = _mapper.Map<ShippingMethod, ShippingDetailsViewModel>(shippingMethod);
			return View(model);
		}
		[HttpGet]
		public IActionResult ShippingMethods()
		{
			List<ShippingMethod> shippingMethods = _storeRepository.GetShippingMethods();
			List<ShippingMethodItemViewModel> model = _mapper.Map<List<ShippingMethod>, List<ShippingMethodItemViewModel>>(shippingMethods);
			return View(model);
		}

		[HttpGet]
		public IActionResult ShowProduct(Guid id)
		{
			Product product = _storeRepository.GetProductById(id);
			ShowProductViewModel model = _mapper.Map<Product, ShowProductViewModel>(product);
			return View(model);
		}
		[HttpDelete]
		public IActionResult DeleteProduct(Guid id)
		{
			_storeRepository.DeleteProduct(id);
			_unitOfWOrk.Commit();
			return RedirectToAction(nameof(this.ShoppingCart));
		}

		[HttpGet]
		public IActionResult OrderHistory(Guid statusId, DateTime fromDate, DateTime toDate)
		{
			List<OrderProvider> orders = _storeRepository.GetOrders(statusId, fromDate, toDate);
			List<OrderHistoryItemViewModel> model = _mapper.Map<List<OrderProvider>, List<OrderHistoryItemViewModel>>(orders);
			return View(model);
		}

		[HttpGet]
		public IActionResult ShoppingCart(Guid id)
		{
			List<OrderItem> items = _storeRepository.GetOrderItems(id);
			List<OrderItemViewModel> model = _mapper.Map<List<OrderItem>, List<OrderItemViewModel>>(items);
			return View(model);
		}

		[HttpGet]
		public IActionResult ShowDepartments()
		{
			List<Department> departments = _storeRepository.GetDepartments();
			List<DepartmentItemViewModel> model = _mapper.Map<List<Department>, List<DepartmentItemViewModel>>(departments);
			return View(model);
		}

		[HttpPost]
		public IActionResult SendShippingAddress(ShippingAddressViewModel model)
		{
			return View();
		}
		[HttpGet]
		public IActionResult BrowseProducts(Guid departmentId)
		{
			return View();
		}
		#region Private methods
		private Expression<Func<ProductProvider, dynamic>> GetSortExpession(string orderBy)
		{
			Expression<Func<ProductProvider, dynamic>> expression = null;
			switch (orderBy)
			{
				case (nameof(ProductProvider.AddedBy)):
					expression = p => p.AddedBy;
					break;
				default:
					expression = p => p.AddedDate;
					break;
			}
			return expression;
		}
		#endregion
	}
}
