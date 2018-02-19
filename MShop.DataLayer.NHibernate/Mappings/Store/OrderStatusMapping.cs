using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Store; 

namespace MShop.DataLayer.NHibernate.Mappings.Store
{
	public class OrderStatusMapping : ClassMap<OrderStatus>
	{
		public OrderStatusMapping()
		{
			Table("OrderStatuses");
			Id(m => m.Id).GeneratedBy.Identity();
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			HasMany(x => x.Orders).KeyColumn("Id");
		}
	}
}
