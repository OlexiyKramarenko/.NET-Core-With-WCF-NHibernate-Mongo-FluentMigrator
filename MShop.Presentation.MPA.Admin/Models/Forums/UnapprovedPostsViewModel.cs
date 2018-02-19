using System;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Forums
{
    public class UnapprovedPostItemViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AddedBy { get; set; }
        public string Body { get; set; }
        public string ForumTitle { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime LastPostDate { get; set; }
    }
}
