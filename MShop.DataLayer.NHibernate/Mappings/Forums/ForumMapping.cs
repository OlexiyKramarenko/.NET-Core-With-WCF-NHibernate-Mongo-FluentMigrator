using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Forums;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Mappings.Forums
{
	public class ForumMapping : ClassMap<Forum>
	{
		public ForumMapping()
		{
			Table("Forums");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.Moderated);
			Map(m => m.Importance);
			Map(m => m.Description).Length(5000);
			Map(m => m.ImageUrl);
			HasMany(x => (List<Post>)x.Posts).KeyColumn("ForumId").Cascade.All();
		}
	}
}
