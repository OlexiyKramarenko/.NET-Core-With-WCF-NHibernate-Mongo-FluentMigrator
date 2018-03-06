using MShop.DataLayer.Entities.Forums;
using System;
using System.Collections.Generic;
namespace MShop.DataLayer.NHibernate.Entities.Forums
{
	public class Forum : IForum
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string Title { get; set; }
		public virtual bool Moderated { get; set; }
		public virtual int Importance { get; set; }
		public virtual string Description { get; set; }
		public virtual string ImageUrl { get; set; }
		public virtual IList<IPost> Posts { get; set; }
	}
}
