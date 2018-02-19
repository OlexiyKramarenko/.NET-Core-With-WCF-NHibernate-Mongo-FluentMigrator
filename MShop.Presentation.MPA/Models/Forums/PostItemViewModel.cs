
using System;

namespace MShop.Presentation.MPA.Public.Models.Forums
{
    public class PostItemViewModel
    {
        public Guid ForumId { get; set; }
        public Guid ThreadId { get; set; }
        public Guid PostId { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int QuotePostId { get; set; }
    }
}
