using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Entities.Store
{
	public class Order : IOrder
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string ShippingMethod { get; set; }
		public virtual decimal SubTotal { get; set; }
		public virtual decimal Shipping { get; set; }
		public virtual string ShippingFirstName { get; set; }
		public virtual string ShippingLastName { get; set; }
		public virtual string ShippingStreet { get; set; }
		public virtual string ShippingPostalCode { get; set; }
		public virtual string ShippingCity { get; set; }
		public virtual string ShippingState { get; set; }
		public virtual string ShippingCountry { get; set; }
		public virtual string CustomerEmail { get; set; }
		public virtual string CustomerPhone { get; set; }
		public virtual string CustomerFax { get; set; }
		public virtual string TransactionId { get; set; }
		public virtual DateTime? ShippedDate { get; set; }
		public virtual string TrackingId { get; set; }
		public virtual IList<IOrderItem> OrderItems { get; set; }
		public virtual IOrderStatus OrderStatus { get; set; }
	}
}
