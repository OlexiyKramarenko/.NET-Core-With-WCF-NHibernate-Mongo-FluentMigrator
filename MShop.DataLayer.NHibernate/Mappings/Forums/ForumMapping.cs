using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Forums; 

namespace MShop.DataLayer.NHibernate.Mappings.Forums
{
	public class ForumMapping : ClassMap<Forum>
	{
		public ForumMapping()
		{
			Table("Forums");
			Id(m => m.Id).GeneratedBy.Identity();
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.Moderated);
			Map(m => m.Importance);
			Map(m => m.Description);
			Map(m => m.ImageUrl);
			HasMany(x => x.Posts);//.KeyColumn("Id");
		}
	}
}
