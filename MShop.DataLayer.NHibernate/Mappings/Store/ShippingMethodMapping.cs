using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Store;

namespace MShop.DataLayer.NHibernate.Mappings.Store
{
	public class ShippingMethodMapping : ClassMap<ShippingMethod>
	{
		public ShippingMethodMapping()
		{
			Table("ShippingMethods");
			Id(m => m.Id).GeneratedBy.Identity();
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.Price);
		}
	}
}
