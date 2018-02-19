using MShop.DataLayer.Entities.Store;
using System;

namespace MShop.DataLayer.NHibernate.Entities.Store
{
	public class OrderItem : IOrderItem
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual Guid OrderId { get; set; }
		public virtual Guid ProductId { get; set; }
		public virtual string Title { get; set; }
		public virtual string SKU { get; set; }
		public virtual decimal UnitPrice { get; set; }
		public virtual int Quantity { get; set; }
		public virtual Order Order { get; set; }
	}
}
