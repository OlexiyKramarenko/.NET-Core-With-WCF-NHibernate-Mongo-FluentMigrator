using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.EF.Entities.Store
{
	public class Order : IOrder
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid StatusId { get; set; }
		public string ShippingMethod { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Shipping { get; set; }
		public string ShippingFirstName { get; set; }
		public string ShippingLastName { get; set; }
		public string ShippingStreet { get; set; }
		public string ShippingPostalCode { get; set; }
		public string ShippingCity { get; set; }
		public string ShippingState { get; set; }
		public string ShippingCountry { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerFax { get; set; }
		public string TransactionId { get; set; }
		public DateTime? ShippedDate { get; set; }
		public string TrackingId { get; set; }
		public IList<IOrderItem> OrderItems { get; set; } = new List<IOrderItem>();
		public IOrderStatus OrderStatus { get; set; }

	}
}
