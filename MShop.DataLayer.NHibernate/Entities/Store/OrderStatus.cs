using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Entities.Store
{
	public class OrderStatus : IOrderStatus
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string Title { get; set; }
		public virtual IList<IOrder> Orders { get; set; }
	}
}
