using System;


namespace MShop.DataLayer.Entities.Store
{
	public interface IOrderStatus
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
	}
}
