using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Articles;

namespace MShop.DataLayer.NHibernate.Mappings.Articles
{
	public class ArticleMapping : ClassMap<Article>
	{
		public ArticleMapping()
		{
			Table("Articles");
			Id(m => m.Id).GeneratedBy.Identity();			
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			//Map(m => m.CategoryId);
			Map(m => m.Title);
			Map(m => m.Abstract);
			Map(m => m.Body);
			Map(m => m.Country);
			Map(m => m.State);
			Map(m => m.City);
			Map(m => m.ReleaseDate);
			Map(m => m.ExpireDate);
			Map(m => m.Approved);
			Map(m => m.Listed);
			Map(m => m.CommentsEnabled);
			Map(m => m.OnlyForMembers);
			Map(m => m.ViewCount);
			Map(m => m.Votes);
			Map(m => m.TotalRating);
			HasMany(x => x.Comments);//.KeyColumn("Id");
			References(m => m.Category).Column("CategoryId").Cascade.All();
		}
	}
}