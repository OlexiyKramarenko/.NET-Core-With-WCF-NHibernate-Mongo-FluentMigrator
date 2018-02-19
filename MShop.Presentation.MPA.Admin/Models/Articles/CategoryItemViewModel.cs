using System;

namespace MShop.Presentation.MPA.Admin.Models.Articles
{
    public class CategoryItemViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
