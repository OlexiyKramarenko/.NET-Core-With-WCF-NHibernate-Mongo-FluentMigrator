using MShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.EF.Entities.Store
{
	public class OrderStatus : IOrderStatus
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public IList<IOrder> Orders { get; set; }
	}
}
