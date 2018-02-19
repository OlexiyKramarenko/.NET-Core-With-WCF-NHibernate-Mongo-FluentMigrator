using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Admin.Models.Forums
{
    public class ThreadViewModel
    {
        public Guid ForumTitleId { get; set; }
        public string ThreadTitle { get; set; }
        public string ForumTitle { get; set; }
        public List<SelectListItem> Forums { get; set; }
    }
}
