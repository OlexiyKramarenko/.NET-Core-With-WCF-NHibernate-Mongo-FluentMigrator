using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Articles;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Mappings.Articles
{
	public class CategoryMapping : ClassMap<Category>
	{
		public CategoryMapping()
		{
			Table("Categories");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.Importance);
			Map(m => m.Description).Length(5000); 
			Map(m => m.ImageUrl);
			HasMany(x => (List<Article>)x.Articles).KeyColumn("CategoryId").Cascade.All();
		}
	}
}
