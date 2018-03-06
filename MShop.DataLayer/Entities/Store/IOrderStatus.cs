using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Entities.Store
{
	public interface IOrderStatus
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		IList<IOrder> Orders { get; set; }
	}
}
