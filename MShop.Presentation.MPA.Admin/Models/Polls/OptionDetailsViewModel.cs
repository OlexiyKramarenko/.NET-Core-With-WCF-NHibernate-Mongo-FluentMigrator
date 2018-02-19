
using System;

namespace MShop.Presentation.MPA.Admin.Models.Polls
{
    public class OptionDetailsViewModel
    {
        public Guid Id { get; set; }
        public int AddedDate { get; set; }
        public int AddedBy { get; set; }
        public int Votes { get; set; }
        public int Percentage { get; set; }
        public string OptionText { get; set; }
    }
}
