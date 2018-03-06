using MShop.DataLayer.Entities.Forums;
using System;

namespace MShop.DataLayer.EF.Entities.Forums
{
	public class Post : IPost
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string AddedByIP { get; set; }
		public Guid ForumId { get; set; }
		public Guid ParentPostId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public bool Approved { get; set; }
		public bool Closed { get; set; }
		public int ViewCount { get; set; }
		public int ReplyCount { get; set; }
		public DateTime LastPostDate { get; set; }
		public string LastPostBy { get; set; }
		public bool IsThreadPost { get; set; }
		public IForum Forum { get; set; }
	}
}
