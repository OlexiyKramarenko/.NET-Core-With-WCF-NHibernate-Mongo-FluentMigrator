
using System;

namespace MShop.Presentation.MPA.Admin.Models.Forums
{
    public class ManageForumItemViewModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string ForumTitle { get; set; }
        public bool IsModerated { get; set; }
        public string Description { get; set; }
    }
}
