using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Forums;

namespace MShop.DataLayer.NHibernate.Mappings.Forums
{
	public class PostMapping : ClassMap<Post>
	{
		public PostMapping()
		{
			Table("Posts");
			Id(m => m.Id).GeneratedBy.Identity();
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.AddedByIP);
			Map(m => m.ForumId);
			Map(m => m.ParentPostId);
			Map(m => m.Title);
			Map(m => m.Body);
			Map(m => m.Approved);
			Map(m => m.Closed);
			Map(m => m.ViewCount);
			Map(m => m.ReplyCount);
			Map(m => m.LastPostDate);
			Map(m => m.LastPostBy);
			Map(m => m.IsThreadPost);
			References(m => m.Forum).Column("ForumId").Cascade.All();
		}
	}
}
