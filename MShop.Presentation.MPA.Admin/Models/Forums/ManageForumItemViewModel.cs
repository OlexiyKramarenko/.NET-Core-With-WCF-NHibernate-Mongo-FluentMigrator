
using System;

namespace MShop.Presentation.MPA.Admin.Models.Forums
{
    public class ManageForumItemViewModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public bool Moderated { get; set; }
        public string Description { get; set; }
    }
}
