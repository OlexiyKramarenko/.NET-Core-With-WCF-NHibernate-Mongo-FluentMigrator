using System;
using System.ComponentModel.DataAnnotations;

namespace MShop.ViewComponents.Models
{
	public class OrderItemViewModel
	{
		public Guid Id { get; set; }
		public int ProductId { get; set; }
		public string Title { get; set; }
		public decimal UnitPrice { get; set; }
		public string SKU { get; set; }
		[Required]
		public int Quantity { get; set; }
	}
}
