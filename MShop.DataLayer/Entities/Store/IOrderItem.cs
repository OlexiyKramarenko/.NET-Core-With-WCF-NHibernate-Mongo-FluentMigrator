using System;

namespace MShop.DataLayer.Entities.Store
{
	public interface IOrderItem
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; } 
		string Title { get; set; }
		string SKU { get; set; }
		decimal UnitPrice { get; set; }
		int Quantity { get; set; } 
	}
}
