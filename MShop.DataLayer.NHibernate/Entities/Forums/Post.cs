using MShop.DataLayer.Entities.Forums;
using System;

namespace MShop.DataLayer.NHibernate.Entities.Forums
{
	public class Post : IPost
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string AddedByIP { get; set; }
		public virtual Guid ParentPostId { get; set; }
		public virtual string Title { get; set; }
		public virtual string Body { get; set; }
		public virtual bool Approved { get; set; }
		public virtual bool Closed { get; set; }
		public virtual int ViewCount { get; set; }
		public virtual int ReplyCount { get; set; }
		public virtual DateTime LastPostDate { get; set; }
		public virtual string LastPostBy { get; set; }
		public virtual bool IsThreadPost { get; set; }
		public virtual IForum Forum { get; set; }
	}
}
