using System;

namespace MShop.Presentation.MPA.Public.Models.Forums
{
    public class ThreadItemViewModel
    {
		public Guid Id { get; set; }
		public Guid ForumId { get; set; }
		public int ReplyCount { get; set; }
        public string Title { get; set; }        
        public string AddedBy { get; set; }
        public DateTime LastPostDate { get; set; }
        public string LastPostBy { get; set; }
        public int ViewCount { get; set; }
    }
}
