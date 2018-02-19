
using System;

namespace MShop.Presentation.MPA.Admin.Models.Polls
{
    public class OptionItemViewModel
    {
        public Guid Id { get; set; }
        public string OptionText { get; set; }
        public int Votes { get; set; }
        public int Percentage { get; set; }
    }
}
