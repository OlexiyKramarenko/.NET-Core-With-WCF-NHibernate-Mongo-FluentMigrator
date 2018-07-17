using MShop.DataLayer.Entities.Articles;
using System;

namespace MShop.DataLayer.NHibernate.Entities.Articles
{
	public class Comment : IComment
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string AddedByEmail { get; set; }
		public virtual string AddedByIp { get; set; }
		public virtual string Body { get; set; }
		public virtual IArticle Article { get; set; }
	} 
}
