using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MShop.DataLayer.Providers.Store;
using MShop.DataLayer.Repositories;
using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.EF.Providers.Store;
using Microsoft.EntityFrameworkCore;

namespace MShop.DataLayer.EF.Repositories
{
	public class StoreRepository : IStoreRepository<Department, OrderStatus, ShippingMethod, Product, Order, OrderItem, OrderProvider, ProductProvider, Guid>
	{
		private readonly EfUnitOfWork _unitOfWork;

		public StoreRepository(EfUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region Public Methods
		public List<Department> GetDepartments()
		{
			List<Department> departments = _unitOfWork.Context
				.Departments
				.OrderByDescending(a => a.Importance)
				.ThenBy(a => a.Title)
				.ToList();

			return departments ?? new List<Department>();
		}
		public Department GetDepartmentById(Guid departmentId)
		{
			Department department = _unitOfWork.Context
				.Departments
				.Find(departmentId);

			return department;
		}
		public void DeleteDepartment(Guid departmentId)
		{
			Department department = _unitOfWork.Context
				.Departments
				.Find(departmentId);

			if (department != null)
				_unitOfWork.Context.Departments.Remove(department);
		}
		public void UpdateDepartment(Department department)
		{
			Department ctxDepartment = _unitOfWork.Context
				.Departments
				.Find(department.Id);
			if (ctxDepartment != null)
			{
				ctxDepartment.Title = department.Title;
				ctxDepartment.Importance = department.Importance;
				ctxDepartment.Description = department.Description;
				ctxDepartment.ImageUrl = department.ImageUrl;
			}
		}
		public void InsertDepartment(Department department)
		{
			Expression<Func<Department, bool>> expression = (dep) =>
				dep.Title.ToLower() == department.Title.ToLower();

			bool any = _unitOfWork.Context
				.Departments
				.Any(expression);
			if (any)
			{
				throw new Exception();
			}
			_unitOfWork.Context.Departments.Add(department);
		}

		public List<OrderStatus> GetOrderStatuses()
		{
			List<OrderStatus> orderStatuses = _unitOfWork.Context
				.OrderStatuses
				.ToList();

			return orderStatuses ?? new List<OrderStatus>();
		}
		public OrderStatus GetOrderStatusById(Guid orderStatusId)
		{
			OrderStatus orderStatus = _unitOfWork.Context
				.OrderStatuses
				.Find(orderStatusId);
			return orderStatus;
		}
		public void DeleteOrderStatus(Guid orderStatusId)
		{
			OrderStatus orderStatus = _unitOfWork.Context
				.OrderStatuses
				.Find(orderStatusId);
			if (orderStatus != null)
				_unitOfWork.Context.OrderStatuses.Remove(orderStatus);
		}
		public void UpdateOrderStatus(OrderStatus orderStatus)
		{
			OrderStatus ctxOrderStatus = _unitOfWork.Context
				.OrderStatuses
				.Find(orderStatus.Id);
			if (ctxOrderStatus != null)
				orderStatus.Title = orderStatus.Title;
		}

		public void InsertOrderStatus(OrderStatus orderStatus)
		{
			bool any = _unitOfWork.Context
				.OrderStatuses
				.Any(a => a.Title.ToLower() == orderStatus.Title.ToLower());
			if (any)
				throw new Exception("Order status already exists.");

			_unitOfWork.Context.OrderStatuses.Add(orderStatus);
		}

		public List<ShippingMethod> GetShippingMethods()
		{
			List<ShippingMethod> shippingMethods = _unitOfWork.Context
				.ShippingMethods
				.OrderBy(a => a.Price)
				.AsNoTracking()
				.ToList();
			return shippingMethods ?? new List<ShippingMethod>();
		}

		public ShippingMethod GetShippingMethodById(Guid shippingMethodId)
		{
			ShippingMethod shippingMethod = _unitOfWork.Context
				.ShippingMethods
				.Find(shippingMethodId);
			return shippingMethod;
		}
		public void DeleteShippingMethod(Guid shippingMethodId)
		{
			ShippingMethod shippingMethod = _unitOfWork.Context
				.ShippingMethods
				.Find(shippingMethodId);
			if (shippingMethod != null)
				_unitOfWork.Context.ShippingMethods.Remove(shippingMethod);
		}
		public void UpdateShippingMethod(ShippingMethod shippingMethod)
		{
			ShippingMethod ctxShippingMethod = _unitOfWork.Context
				.ShippingMethods
				.Find(shippingMethod.Id);
			if (ctxShippingMethod != null)
			{
				ctxShippingMethod.Title = shippingMethod.Title;
				ctxShippingMethod.Price = ctxShippingMethod.Price;
			}
		}
		public void InsertShippingMethod(ShippingMethod shippingMethod)
		{
			ShippingMethod ctxShippingMethod = _unitOfWork.Context
				.ShippingMethods
				.Find(shippingMethod.Id);
			if (ctxShippingMethod != null)
				throw new Exception("ShippingMethod already exists.");

			_unitOfWork.Context.ShippingMethods.Add(shippingMethod);
		}

		public List<ProductProvider> GetProducts(Expression<Func<ProductProvider, dynamic>> sortExpression,
			int pageIndex,
			int pageSize)
		{
			int skipCount = (pageIndex - 1) * pageSize;
			List<ProductProvider> products = this.GetProductsQuery()
				.OrderBy(sortExpression)
				.Skip(skipCount)
				.Take(pageSize)
				.ToList();

			return products ?? new List<ProductProvider>();
		}
		public List<ProductProvider> GetProducts(Guid departmentId, int pageIndex, int pageSize)
		{
			int skipCount = (pageIndex - 1) * pageSize;
			List<ProductProvider> products = this.GetProductsQuery()
				.Where(p => p.DepartmentId == departmentId)
				.Skip(skipCount)
				.Take(pageSize)
				.ToList();

			return products ?? new List<ProductProvider>();
		}
		public int GetProductCount()
		{
			int count = _unitOfWork.Context
				.Products
				.AsNoTracking()
				.Count();
			return count;
		}
		public int GetProductCount(Guid departmentId)
		{
			int count = _unitOfWork.Context
				.Products
				.AsNoTracking()
				.Count(a => a.DepartmentId == departmentId);
			return count;
		}
		public Product GetProductById(Guid productId)
		{
			Product product = _unitOfWork.Context
				.Products
				.Find(productId);
			return product;
		}
		public void DeleteProduct(Guid productId)
		{
			Product product = _unitOfWork.Context
				.Products
				.Find(productId);
			if (product != null)
				_unitOfWork.Context.Products.Remove(product);
		}
		public void UpdateProduct(Product product)
		{
			Product ctxProduct = _unitOfWork.Context
				.Products
				.Find(product.Id);
			if (ctxProduct != null)
			{
				ctxProduct.DepartmentId = product.DepartmentId;
				ctxProduct.Title = product.Title;
				ctxProduct.Description = product.Description;
				ctxProduct.SKU = product.SKU;
				ctxProduct.UnitPrice = product.UnitPrice;
				ctxProduct.DiscountPercentage = product.DiscountPercentage;
				ctxProduct.UnitsInStock = product.UnitsInStock;
				ctxProduct.SmallImageUrl = product.SmallImageUrl;
				ctxProduct.FullImageUrl = product.FullImageUrl;
			}
		}
		public void InsertProduct(Product product)
		{
			_unitOfWork.Context.Products.Add(product);
		}
		public void RateProduct(Guid productId, int rating)
		{
			Product ctxProduct = _unitOfWork.Context
				.Products
				.Find(productId);
			if (ctxProduct != null)
			{
				ctxProduct.Votes++;
				ctxProduct.TotalRating = ctxProduct.TotalRating + rating;
			}
		}

		public void DecrementProductUnitsInStock(Guid productId, int quantity)
		{
			Product product = _unitOfWork.Context
				.Products
				.Find(productId);
			if (product != null)
				product.UnitsInStock = product.UnitsInStock - quantity;
		}
		public string GetProductDescription(Guid productId)
		{
			Product product = _unitOfWork.Context
				.Products
				.Find(productId);
			return product?.Description;
		}
		public List<OrderProvider> GetOrders(int pageIndex, int pageSize)
		{
			int skipCount = (pageIndex - 1) * pageSize;
			List<OrderProvider> orders = this.GetOrdersQuery()
				.OrderBy(a => a.AddedDate)
				.Skip(skipCount)
				.Take(pageSize)
				.AsNoTracking()
				.ToList();
			foreach (var item in orders)
			{
				item.OrderItems = this.GetOrderItems(item.Id);
			}
			return orders ?? new List<OrderProvider>();
		}
		public List<OrderProvider> GetOrders(Guid statusId, DateTime fromDate, DateTime toDate)
		{
			List<OrderProvider> orders = this.GetOrdersQuery()
				.Where(o => o.StatusId == statusId &&
							o.AddedDate >= fromDate &&
							o.AddedDate <= toDate)
				.OrderBy(a => a.AddedDate)
				.AsNoTracking()
				.ToList();
			return orders ?? new List<OrderProvider>();
		}
		public List<OrderProvider> GetOrders(string addedBy)
		{
			List<OrderProvider> orders = this.GetOrdersQuery()
				.Where(o => o.AddedBy == addedBy)
				.OrderByDescending(a => a.AddedDate)
				.ToList();
			foreach (var item in orders)
			{
				item.OrderItems = this.GetOrderItems(item.Id);
			}
			return orders ?? new List<OrderProvider>();
		}


		public OrderProvider GetOrderById(Guid orderId)
		{
			OrderProvider order = this.GetOrdersQuery()
									  .AsNoTracking()
									  .SingleOrDefault(a => a.Id == orderId);
			return order;
		}
		public void DeleteOrder(Guid orderId)
		{
			Order order = _unitOfWork.Context
				.Orders
				.Find(orderId);
			if (order != null)
				_unitOfWork.Context.Orders.Remove(order);
		}
		public void InsertOrder(Order order)
		{
			_unitOfWork.Context.Orders.Add(order);
		}
		public void UpdateOrder(Order order)
		{
			Order ctxOrder = _unitOfWork.Context
				.Orders
				.Find(order.Id);
			if (ctxOrder != null)
			{
				ctxOrder.StatusId = order.StatusId;
				ctxOrder.ShippedDate = order.ShippedDate;
				ctxOrder.TransactionId = order.TransactionId;
				ctxOrder.TrackingId = order.TrackingId;
			}
		}
		public List<OrderItem> GetOrderItems(Guid orderId)
		{
			try
			{
				List<OrderItem> orderItems = _unitOfWork.Context
					.OrderItems
					.Where(a => a.OrderId == orderId)?
					.ToList();
				return orderItems ?? new List<OrderItem>();
			}
			catch (Exception exc)
			{
				return null;
			}

		}
		public void InsertOrderItem(OrderItem orderItem)
		{
			_unitOfWork.Context.OrderItems.Add(orderItem);
		}

		#endregion

		#region  Private Methods

		private IQueryable<ProductProvider> GetProductsQuery()
		{
			IQueryable<ProductProvider> query = from product in _unitOfWork.Context.Products
												join department in _unitOfWork.Context.Departments
												on product.DepartmentId equals department.Id
												select new ProductProvider
												{
													Id = product.Id,
													AddedBy = product.AddedBy,
													AddedDate = product.AddedDate,
													DepartmentId = product.DepartmentId,
													DepartmentTitle = department.Title,
													Description = product.Description,
													DiscountPercentage = product.DiscountPercentage,
													SmallImageUrl = product.SmallImageUrl,
													FullImageUrl = product.FullImageUrl,
													SKU = product.SKU,
													UnitPrice = product.UnitPrice,
													UnitsInStock = product.UnitsInStock,
													Votes = product.Votes
												};
			return query;
		}

		private IQueryable<OrderProvider> GetOrdersQuery()
		{
			IQueryable<OrderProvider> query = from order in _unitOfWork.Context.Orders.Include("OrderItems")
											  join orderStatus in _unitOfWork.Context.OrderStatuses
											  on order.StatusId equals orderStatus.Id
											  select new OrderProvider
											  {
												  Id = order.Id,
												  AddedDate = order.AddedDate,
												  AddedBy = order.AddedBy,
												  StatusId = order.StatusId,
												  ShippingMethod = order.ShippingMethod,
												  SubTotal = order.SubTotal,
												  Shipping = order.Shipping,
												  ShippingFirstName = order.ShippingFirstName,
												  ShippingLastName = order.ShippingLastName,
												  ShippingStreet = order.ShippingStreet,
												  ShippingPostalCode = order.ShippingPostalCode,
												  ShippingCity = order.ShippingCity,
												  ShippingState = order.ShippingState,
												  ShippingCountry = order.ShippingCountry,
												  CustomerEmail = order.CustomerEmail,
												  CustomerPhone = order.CustomerPhone,
												  CustomerFax = order.CustomerFax,
												  ShippedDate = order.ShippedDate,
												  TransactionId = order.TransactionId,
												  TrackingId = order.TrackingId,
												  StatusTitle = orderStatus.Title,

											  };
			return query;
		}

		public void UpdateOrderStatusId(Guid orderId, Guid statusId)
		{
			Order order = _unitOfWork.Context.Orders.Find(orderId);
			if (order != null)
			{
				order.StatusId = statusId;
			}
		}
		#endregion
	}
}
