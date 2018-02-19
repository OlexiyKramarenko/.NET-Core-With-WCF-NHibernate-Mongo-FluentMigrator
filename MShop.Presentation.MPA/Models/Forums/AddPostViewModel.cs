
using System;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Public.Models.Forums
{
    public class AddPostViewModel
    {
        public Guid ThreadId { get; set; }
        public Guid ForumId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Closed { get; set; }
    }
}
