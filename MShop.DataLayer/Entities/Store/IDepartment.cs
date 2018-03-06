using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Entities.Store
{
	public interface IDepartment
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; }
		IList<IProduct> Products { get; set; }
	}
}
