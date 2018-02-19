using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Store;

namespace MShop.DataLayer.NHibernate.Mappings.Store
{
	public class DepartmentMapping : ClassMap<Department>
	{
		public DepartmentMapping()
		{
			Table("Departments");
			Id(m => m.Id).GeneratedBy.Identity();
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.Importance);
			Map(m => m.Description);
			Map(m => m.ImageUrl);
			HasMany(x => x.Products).KeyColumn("Id");
		}
	}
}
