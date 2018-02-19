
using System;

namespace MShop.Presentation.MPA.Admin.Models.Polls
{
    public class PollItemViewModel
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public int Votes { get; set; }
        public bool IsCurrent { get; set; }
    }
}
