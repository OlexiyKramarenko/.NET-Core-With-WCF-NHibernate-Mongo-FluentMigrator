using System;

namespace MShop.DataLayer.Entities.Articles
{
	public interface IComment
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string AddedByEmail { get; set; }
		string AddedByIp { get; set; }
		string Body { get; set; }
	}
}
