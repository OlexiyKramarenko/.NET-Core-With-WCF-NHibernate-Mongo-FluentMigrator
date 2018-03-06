using System;

namespace MShop.DataLayer.Entities.Forums
{
	public interface IPost
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string AddedByIP { get; set; }
		string Title { get; set; }
		string Body { get; set; }
		bool Approved { get; set; }
		bool Closed { get; set; }
		int ViewCount { get; set; }
		int ReplyCount { get; set; }
		DateTime LastPostDate { get; set; }
		string LastPostBy { get; set; }
		bool IsThreadPost { get; set; }
		IForum Forum { get; set; }
	}
}
