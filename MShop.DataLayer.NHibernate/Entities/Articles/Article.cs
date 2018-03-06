using MShop.DataLayer.Entities.Articles;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Entities.Articles
{
	public class Article : IArticle
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual Guid CategoryId { get; set; }
		public virtual string Title { get; set; }
		public virtual string Abstract { get; set; }
		public virtual string Body { get; set; }
		public virtual string Country { get; set; }
		public virtual string State { get; set; }
		public virtual string City { get; set; }
		public virtual DateTime ReleaseDate { get; set; }
		public virtual DateTime ExpireDate { get; set; }
		public virtual bool Approved { get; set; }
		public virtual bool Listed { get; set; }
		public virtual bool CommentsEnabled { get; set; }
		public virtual bool OnlyForMembers { get; set; }
		public virtual int ViewCount { get; set; }
		public virtual int Votes { get; set; }
		public virtual int TotalRating { get; set; }
		public virtual IList<IComment> Comments { get; set; }
		public virtual ICategory Category { get; set; }
	}
}
