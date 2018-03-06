using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Providers.Store;
using MShop.Presentation.MPA.Public.Models.Store;
using MShop.Presentation.MPA.Public.Infrastructure.Extensions;
using IStoreRepository = MShop.DataLayer.Repositories.IStoreRepository<
	MShop.DataLayer.EF.Entities.Store.Department,
	MShop.DataLayer.EF.Entities.Store.OrderStatus,
	MShop.DataLayer.EF.Entities.Store.ShippingMethod,
	MShop.DataLayer.EF.Entities.Store.Product,
	MShop.DataLayer.EF.Entities.Store.Order,
	MShop.DataLayer.EF.Entities.Store.OrderItem,
	MShop.DataLayer.EF.Providers.Store.OrderProvider,
	MShop.DataLayer.Providers.Store.ProductProvider, System.Guid>;
using System.Linq;
using MShop.Presentation.MPA.Public.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MShop.Presentation.MPA.Public.Controllers
{
	public class StoreController : Controller
	{
		private readonly IStoreRepository _storeRepository;
		private readonly IUnitOfWork _unitOfWOrk;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private ISession _session => _httpContextAccessor.HttpContext.Session;

		public StoreController(IStoreRepository storeRepository, IUnitOfWork unitOfWOrk, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_storeRepository = storeRepository;
			_unitOfWOrk = unitOfWOrk;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
		}

		#region Products
		[HttpGet]
		public IActionResult ShowProduct(Guid id)
		{
			Product product = _storeRepository.GetProductById(id);
			var model = _mapper.Map<ShowProductViewModel>(product);
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
		public IActionResult BrowseProducts(Guid departmentId)
		{
			return View(departmentId);
		}

		[HttpGet]
		public IActionResult ShowDepartments()
		{
			List<Department> departments = _storeRepository.GetDepartments();
			var model = _mapper.Map<List<DepartmentItemViewModel>>(departments);
			return View(model);
		}
		#endregion

		#region Shipping
		[HttpGet]
		public IActionResult ShippingDetails(Guid id)
		{
			ShippingMethod shippingMethod = _storeRepository.GetShippingMethodById(id);
			var model = _mapper.Map<ShippingDetailsViewModel>(shippingMethod);
			return View(model);
		}

		[HttpGet]
		public IActionResult ShippingMethods()
		{
			List<ShippingMethod> shippingMethods = _storeRepository.GetShippingMethods();
			var model = _mapper.Map<List<ShippingMethodItemViewModel>>(shippingMethods);
			return View(model);
		}

		[HttpGet]
		public IActionResult Checkout()
		{
			CheckoutViewModel model = null;
			if (_session.Keys.Contains(Constants.Checkout))
			{
				model = _session.Get<CheckoutViewModel>(Constants.Checkout);
				_session.Set(Constants.Checkout, model);
			}
			else
			{
				model = new CheckoutViewModel();
			}
			List<ShippingMethod> shippingMethods = _storeRepository.GetShippingMethods();
			var shippingMethodsModel = _mapper.Map<List<ShippingMethodItemViewModel>>(shippingMethods);
			model.ShippingMethods = new SelectList(shippingMethodsModel,
			   nameof(ShippingMethodItemViewModel.Id),
			   nameof(ShippingMethodItemViewModel.Text));

			return View(model);
		}

		[HttpPost]
		public IActionResult Checkout(CheckoutViewModel model)
		{
			_session.Set(Constants.Checkout, model);
			return RedirectToAction(nameof(this.OrderSummary));
		}
		#endregion

		#region ShoppingCart

		[HttpGet]
		public IActionResult ShoppingCart()
		{
			List<ShoppingCartItemViewModel> cart = null;
			if (_session.Keys.Contains(Constants.Cart))
			{
				cart = _session.Get<List<ShoppingCartItemViewModel>>(Constants.Cart);
			}
			return View(cart);
		}

		[HttpPost]
		public IActionResult ShoppingCart(IFormCollection form)
		{
			var id_array = form["item.Id"];
			var quantity_array = form["item.Quantity"];

			List<ShoppingCartItemViewModel> cart = _session.Get<List<ShoppingCartItemViewModel>>(Constants.Cart);
			for (int i = 0; i < id_array.Count; i++)
			{
				Guid id = Guid.Parse(id_array[i]);
				int quantity = Int32.Parse(quantity_array[i]);
				cart.FirstOrDefault(a => a.Id == id).Quantity = quantity;
			}
			_session.Set(Constants.Cart, cart);
			return View(cart);
		}
		
		[HttpPost]
		public IActionResult AddToShoppingCart(ShoppingCartItemViewModel model)
		{
			List<ShoppingCartItemViewModel> cart = null;
			if (_session.Keys.Contains(Constants.Cart))
			{
				cart = _session.Get<List<ShoppingCartItemViewModel>>(Constants.Cart);
				var item = cart.FirstOrDefault(a => a.Id == model.Id);
				if (item == null)
				{
					cart.Add(model);
				}
				else
				{
					cart.FirstOrDefault(a => a.Id == model.Id).Quantity++;
				}
				_session.Set(Constants.Cart, cart);
			}
			else
			{
				cart = new List<ShoppingCartItemViewModel> { model };
				_session.Set(Constants.Cart, cart);
			}
			return RedirectToAction(nameof(this.ShoppingCart));
		}

		[HttpGet]
		public IActionResult RemoveFromShoppingCart(Guid id)
		{
			if (_session.Keys.Contains(Constants.Cart))
			{
				List<ShoppingCartItemViewModel> cart = _session.Get<List<ShoppingCartItemViewModel>>(Constants.Cart);
				ShoppingCartItemViewModel item = cart.Find(a => a.Id == id);
				if (item != null)
				{
					cart.Remove(item);
					_session.Set(Constants.Cart, cart);
				}
			}
			return RedirectToAction(nameof(this.ShoppingCart));
		}
		#endregion

		#region Order

		[HttpGet]
		public IActionResult OrderSummary()
		{
			var cart = _session.Get<List<ShoppingCartItemViewModel>>(Constants.Cart);
			var checkout = _session.Get<CheckoutViewModel>(Constants.Checkout);
			ShippingMethod method = _storeRepository.GetShippingMethodById(Guid.Parse(checkout.ShippingMethodId));
			var summary = new OrderSummaryViewModel
			{
				ShoppingCartItems = cart,
				ShippingDetails = checkout.City + ", " + checkout.PostalCode + ", " + checkout.Street,
				ShippingMethod = method.Title,
				Subtotal = cart.Sum(a => a.UnitPrice * a.Quantity),
				Total = cart.Sum(a => a.UnitPrice * a.Quantity) + method.Price
			};
			return View(summary);
		}

		[HttpPost]
		public IActionResult OrderSummary(OrderSummaryViewModel model)
		{
			return View(null);
		}

		[HttpGet]
		public IActionResult OrderCompleted()
		{
			return View();
		}

		[HttpGet]
		public IActionResult OrderHistory(Guid statusId, DateTime fromDate, DateTime toDate)
		{
			List<OrderProvider> orders = _storeRepository.GetOrders(statusId, fromDate, toDate);
			var model = _mapper.Map<List<OrderHistoryItemViewModel>>(orders);
			return View(model);
		}
		#endregion
	}
}
