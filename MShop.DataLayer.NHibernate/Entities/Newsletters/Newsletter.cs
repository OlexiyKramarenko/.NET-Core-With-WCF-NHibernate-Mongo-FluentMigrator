using MShop.DataLayer.Entities.Newsletters;
using System;

namespace MShop.DataLayer.NHibernate.Entities.Newsletters
{
	public class Newsletter : INewsletter
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string Subject { get; set; }
		public virtual string PlainTextBody { get; set; }
		public virtual string HtmlBody { get; set; }
	}
}
