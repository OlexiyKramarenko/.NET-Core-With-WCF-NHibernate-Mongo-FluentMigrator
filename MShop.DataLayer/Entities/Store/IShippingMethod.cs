using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Entities.Store
{
	public interface IShippingMethod
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		decimal Price { get; set; }
		string Description { get; set; }
	}
}
