using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;
using MShop.DataLayer.Providers.Store;
using System.Linq.Expressions;

namespace MShop.DataLayer.Repositories
{
	public interface IStoreRepository<Department, OrderStatus, ShippingMethod, Product, Order, OrderItem, OrderProvider, ProductProvider, IdType>
		where Department : IDepartment
		where OrderStatus : IOrderStatus
		where ShippingMethod : IShippingMethod
		where Product : IProduct
		where Order : IOrder
		where OrderItem : IOrderItem
		where OrderProvider : IOrderProvider
		where ProductProvider : IProductProvider
	{
		// methods that work with departments
		List<Department> GetDepartments();
		Department GetDepartmentById(IdType departmentId);
		void DeleteDepartment(IdType departmentId);
		void UpdateDepartment(Department department);
		void InsertDepartment(Department department);

		// methods that work with order statuses
		List<OrderStatus> GetOrderStatuses();
		OrderStatus GetOrderStatusById(IdType orderStatusId);
		void DeleteOrderStatus(IdType orderStatusId);
		void UpdateOrderStatus(OrderStatus orderStatus);
		void InsertOrderStatus(OrderStatus orderStatus);

		// methods that work with shipping methods
		List<ShippingMethod> GetShippingMethods();
		ShippingMethod GetShippingMethodById(IdType orderStatusId);
		void DeleteShippingMethod(IdType shippingMethodId);
		void UpdateShippingMethod(ShippingMethod shippingMethod);
		void InsertShippingMethod(ShippingMethod shippingMethod);

		// methods that work with products
		List<ProductProvider> GetProducts(Expression<Func<ProductProvider, dynamic>> sortExpression, int pageIndex, int pageSize);
		List<ProductProvider> GetProducts(IdType departmentId, int pageIndex, int pageSize);
		int GetProductCount();
		int GetProductCount(IdType departmentId);
		Product GetProductById(IdType productId);
		void DeleteProduct(IdType productId);
		void UpdateProduct(Product product);
		void InsertProduct(Product product);
		void RateProduct(IdType productId, int rating);
		void DecrementProductUnitsInStock(IdType productId, int quantity);
		string GetProductDescription(IdType productId);

		// methods that work with orders
		List<OrderProvider> GetOrders(int pageIndex, int pageSize);
		List<OrderProvider> GetOrders(IdType statusId, DateTime fromDate, DateTime toDate);
		List<OrderProvider> GetOrders(string addedBy);
		OrderProvider GetOrderById(IdType orderId);
		void DeleteOrder(IdType orderId);
		void InsertOrder(Order order);
		void UpdateOrder(Order order);

		// methods that work with order items
		List<IOrderItem> GetOrderItems(IdType orderId);
		void InsertOrderItem(OrderItem orderItem);
		void UpdateOrderStatusId(IdType orderId, IdType statusId);
		int GetOrdersCount();
	}
}
