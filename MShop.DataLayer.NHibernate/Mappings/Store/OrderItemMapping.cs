using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Store;

namespace MShop.DataLayer.NHibernate.Mappings.Store
{
	public class OrderItemMapping : ClassMap<OrderItem>
	{
		public OrderItemMapping()
		{
			Table("OrderItems");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.SKU);
			Map(m => m.UnitPrice);
			Map(m => m.Quantity);
			References(m => (Order)m.Order, "OrderId");
		}
	}
}
