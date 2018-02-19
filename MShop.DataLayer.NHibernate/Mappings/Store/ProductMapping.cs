using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Store;

namespace MShop.DataLayer.NHibernate.Mappings.Store
{
	public class ProductMapping : ClassMap<Product>
	{
		public ProductMapping()
		{
			Table("Products");
			Id(m => m.Id).GeneratedBy.Identity();
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.DepartmentId);
			Map(m => m.Title);
			Map(m => m.Description);
			Map(m => m.SKU);
			Map(m => m.UnitPrice);
			Map(m => m.DiscountPercentage);
			Map(m => m.UnitsInStock);
			Map(m => m.SmallImageUrl);
			Map(m => m.FullImageUrl);
			Map(m => m.Votes);
			Map(m => m.TotalRating);
			References(m => m.Department).Column("DepartmentId").Cascade.All();
		}
	}
}
