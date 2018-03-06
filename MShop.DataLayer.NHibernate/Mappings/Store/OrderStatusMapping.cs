using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Store;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Mappings.Store
{
	public class OrderStatusMapping : ClassMap<OrderStatus>
	{
		public OrderStatusMapping()
		{
			Table("OrderStatuses");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			HasMany(x => (List<Order>)x.Orders).KeyColumn("Id");
		}
	}
}
