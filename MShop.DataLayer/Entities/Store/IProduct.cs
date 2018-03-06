using System;

namespace MShop.DataLayer.Entities.Store
{
	public interface IProduct
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }		
		string Title { get; set; }
		string Description { get; set; }
		string SKU { get; set; }
		decimal UnitPrice { get; set; }
		int DiscountPercentage { get; set; }
		int UnitsInStock { get; set; }
		string SmallImageUrl { get; set; }
		string FullImageUrl { get; set; }
		int Votes { get; set; }
		int TotalRating { get; set; }
		IDepartment Department { get; set; }
	}
}
