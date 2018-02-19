using System;

namespace MShop.DataLayer.Entities.Articles
{
	public interface ICategory
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; } 
	}
}
