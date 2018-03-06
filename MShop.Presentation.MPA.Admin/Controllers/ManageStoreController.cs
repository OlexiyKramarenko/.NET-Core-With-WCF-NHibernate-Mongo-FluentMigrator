using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Providers.Store; 
using MShop.Presentation.MPA.Admin.Models.Store;
using MShop.ViewComponents.Models;
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

namespace MShop.Presentation.MPA.Admin.Controllers
{
	public class ManageStoreController : Controller
	{
		private readonly IStoreRepository _storeRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ManageStoreController(IStoreRepository storeRepository, IUnitOfWork unitOfWOrk, IMapper mapper)
		{
			_storeRepository = storeRepository;
			_unitOfWork = unitOfWOrk;
			_mapper = mapper;
		}
		#region Products
		[HttpGet]
		public IActionResult ManageProducts(int pageIndex, int pageSize)
		{
			try
			{
				string controller = nameof(ManageStoreController);
				string action = nameof(this.ManageProducts);
				int count = _storeRepository.GetProductCount();
				var model = new PagerViewModel(count, pageSize, pageIndex, controller, action);
				return View(model); 
			}
			catch
			{
				return View();
			}
		}


		[HttpGet]
		public IActionResult AddProduct()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddProduct(AddProductViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var product = _mapper.Map<Product>(model);
					_storeRepository.InsertProduct(product);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageProducts));
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public IActionResult EditProduct(Guid id)
		{
			Product product = _storeRepository.GetProductById(id);
			var model = _mapper.Map<EditProductViewModel>(product);
			return View(model);
		}

		[HttpPost]
		public IActionResult EditProduct(AddProductViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var product = _mapper.Map<Product>(model);
					_storeRepository.UpdateProduct(product);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageProducts));
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public IActionResult DeleteProduct(Guid id)
		{
			_storeRepository.DeleteProduct(id);
			_unitOfWork.Commit();
			return RedirectToAction(nameof(this.ManageProducts));
		}
		#endregion

		#region ShippingMethod
		[HttpGet]
		public IActionResult ManageShippingMethods()
		{
			try
			{
				IEnumerable<ShippingMethod> list = _storeRepository.GetShippingMethods();
				var model = _mapper.Map<IEnumerable<ManageShippingMethodItemViewModel>>(list);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeleteShippingMethod(Guid id)
		{
			try
			{
				_storeRepository.DeleteShippingMethod(id);
				_unitOfWork.Commit();
				return View(nameof(this.ManageShippingMethods));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddShippingMethod()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddShippingMethod(AddShippingMethodViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var shippingMethod = _mapper.Map<ShippingMethod>(model);
					_storeRepository.InsertShippingMethod(shippingMethod);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageShippingMethods));
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public IActionResult EditShippingMethod(Guid id)
		{
			ShippingMethod method = _storeRepository.GetShippingMethodById(id);
			var model = _mapper.Map<EditShippingMethodViewModel>(method);
			return View(model);
		}

		[HttpPost]
		public IActionResult EditShippingMethod(EditShippingMethodViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var shippingMethod = _mapper.Map<ShippingMethod>(model);
					_storeRepository.UpdateShippingMethod(shippingMethod);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageShippingMethods));
			}
			catch
			{
				return View();
			}
		}
		#endregion

		#region Department
		[HttpGet]
		public IActionResult ManageDepartments()
		{
			try
			{
				List<Department> list = _storeRepository.GetDepartments();
				var model = _mapper.Map<IEnumerable<DepartmentItemViewModel>>(list);
				return View(model);
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public IActionResult DeleteDepartment(Guid id)
		{
			try
			{
				_storeRepository.DeleteDepartment(id);
				_unitOfWork.Commit();
				return View(nameof(this.ManageDepartments));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddDepartment()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddDepartment(AddDepartmentViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var department = _mapper.Map<Department>(model);
					_storeRepository.InsertDepartment(department);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageDepartments));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditDepartment(Guid id)
		{
			Department department = _storeRepository.GetDepartmentById(id);
			var model = _mapper.Map<EditDepartmentViewModel>(department);
			return View(model);
		}

		[HttpPost]
		public IActionResult EditDepartment(EditDepartmentViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var department = _mapper.Map<Department>(model);
					_storeRepository.UpdateDepartment(department);
					_unitOfWork.Commit();
				}
				return RedirectToAction(nameof(this.ManageDepartments));
			}
			catch
			{
				return View();
			}
		}
		#endregion

		#region  Order
		[HttpGet]
		public IActionResult ManageOrders(int pageIndex, int pageSize)
		{
			try
			{
				int itemsCount = _storeRepository.GetOrdersCount();
				string controller = nameof(ManageStoreController);
				string action = nameof(this.ManageOrders);
				List<OrderProvider> list = _storeRepository.GetOrders(pageIndex, pageSize);
				var model = new ManageOrdersViewModel();
				try
				{
					

					model.Pager = new PagerViewModel(itemsCount, pageSize, pageIndex, controller, action);
					model.OrderItems = _mapper.Map<List<ManageOrderItemViewModel>>(list);
				}
				catch(Exception exc)
				{

				}
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeleteOrder(Guid id)
		{
			try
			{
				_storeRepository.DeleteOrder(id);
				_unitOfWork.Commit();
				return View(nameof(this.ManageOrders));
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public IActionResult OrderDetails(Guid id)
		{
			try
			{
				Order order = _storeRepository.GetOrderById(id);
				var model = _mapper.Map<EditOrderViewModel>(order);
				List<OrderStatus> statuses = _storeRepository.GetOrderStatuses();
				model.Items = _mapper.Map<List<Models.Store.OrderItemViewModel>>(order.OrderItems);
				model.OrderStatuses = new SelectList(statuses, "Id", "Title");
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		public IActionResult UpdateOrderStatusId(Guid id, Guid statusId)
		{
			try
			{

				_storeRepository.UpdateOrderStatusId(id, statusId);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageOrders));
			}
			catch
			{
				return View();
			}
		}
		#endregion

		#region  OrderStatus
		[HttpGet]
		public IActionResult ManageOrderStatuses()
		{
			try
			{
				List<OrderStatus> list = _storeRepository.GetOrderStatuses();
				var model = _mapper.Map<List<OrderStatusItemViewModel>>(list);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeleteOrderStatus(Guid id)
		{
			try
			{
				_storeRepository.DeleteOrderStatus(id);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageOrderStatuses));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditOrderStatus(Guid id)
		{
			try
			{
				OrderStatus orderStatus = _storeRepository.GetOrderStatusById(id);
				var model = _mapper.Map<EditOrderStatusViewModel>(orderStatus);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpPut]
		public IActionResult EditOrderStatus(EditOrderStatusViewModel model)
		{
			try
			{
				var status = _mapper.Map<OrderStatus>(model);
				_storeRepository.UpdateOrderStatus(status);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageOrderStatuses));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddOrderStatus()
		{
			return View();
		}

		[HttpPut]
		public IActionResult AddOrderStatus(AddOrderStatusViewModel model)
		{
			try
			{
				var status = _mapper.Map<OrderStatus>(model);
				_storeRepository.InsertOrderStatus(status);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageOrderStatuses));
			}
			catch
			{
				return View();
			}
		}
		#endregion 
	}
}
