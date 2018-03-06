using MShop.DataLayer.Entities.Articles;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Entities.Articles
{
	public class Category : ICategory
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string Title { get; set; }
		public virtual int Importance { get; set; }
		public virtual string Description { get; set; }
		public virtual string ImageUrl { get; set; }
		public virtual IList<IArticle> Articles { get; set; }
	}
}
