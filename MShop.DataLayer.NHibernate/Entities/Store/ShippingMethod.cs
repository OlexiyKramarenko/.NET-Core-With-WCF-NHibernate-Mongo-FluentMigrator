using MShop.DataLayer.Entities.Store;
using System;

namespace MShop.DataLayer.NHibernate.Entities.Store
{
	public class ShippingMethod : IShippingMethod
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string Title { get; set; }
		public virtual decimal Price { get; set; }
	}
}
