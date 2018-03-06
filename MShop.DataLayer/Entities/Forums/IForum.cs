using System;
using System.Collections.Generic;

namespace MShop.DataLayer.Entities.Forums
{
	public interface IForum
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		bool Moderated { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; } 
		IList<IPost> Posts { get; set; }
	}
}
