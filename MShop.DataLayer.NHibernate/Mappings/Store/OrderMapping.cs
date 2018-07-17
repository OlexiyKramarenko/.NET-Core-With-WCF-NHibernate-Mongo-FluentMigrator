using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Store;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Mappings.Store
{
	public class OrderMapping : ClassMap<Order>
	{
		public OrderMapping()
		{
			Table("Orders");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.ShippingMethod);
			Map(m => m.SubTotal);
			Map(m => m.Shipping);
			Map(m => m.ShippingFirstName);
			Map(m => m.ShippingLastName);
			Map(m => m.ShippingStreet);
			Map(m => m.ShippingPostalCode);
			Map(m => m.ShippingCity);
			Map(m => m.ShippingState);
			Map(m => m.ShippingCountry);
			Map(m => m.CustomerEmail);
			Map(m => m.CustomerPhone);
			Map(m => m.CustomerFax);
			Map(m => m.TransactionId);
			Map(m => m.ShippedDate);
			Map(m => m.TrackingId);
			HasMany(x => (List<OrderItem>)x.OrderItems).KeyColumn("OrderId").Cascade.All();
			References(m => (OrderStatus)m.OrderStatus, "OrderStatusId");
		}
	}
}
