using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Articles;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Mappings.Articles
{
	public class ArticleMapping : ClassMap<Article>
	{
		public ArticleMapping()
		{
			Table("Articles");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Title);
			Map(m => m.Abstract).Length(5000); 
			Map(m => m.Body).Length(5000); 
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
			HasMany(x => (List<Comment>)x.Comments).KeyColumn("ArticleId").Cascade.All();
			References(m => (Category)m.Category, "CategoryId");
		}
	}
}