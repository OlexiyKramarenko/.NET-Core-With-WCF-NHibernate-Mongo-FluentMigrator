using MShop.DataLayer.Entities.Store;
using System;

namespace MShop.DataLayer.EF.Entities.Store
{
	public class OrderItem : IOrderItem
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
		public string Title { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }
		public IOrder Order { get; set; }
		public IProduct Product { get; set; }
	}
}
