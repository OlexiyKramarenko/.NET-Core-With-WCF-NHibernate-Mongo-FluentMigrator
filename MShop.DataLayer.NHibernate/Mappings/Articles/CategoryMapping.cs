using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Articles;

namespace MShop.DataLayer.NHibernate.Mappings.Articles
{
	public class CategoryMapping : ClassMap<Category>
	{
		public CategoryMapping()
		{
			Table("Categories");
			Id(m => m.Id).GeneratedBy.Identity();
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.Importance);
			Map(m => m.Description);
			Map(m => m.ImageUrl);
			HasMany(x => x.Articles);//.KeyColumn("Id");
		}
	}
}
