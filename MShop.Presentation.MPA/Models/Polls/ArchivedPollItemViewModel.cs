using System;

namespace MShop.Presentation.MPA.Public.Models.Polls
{
    public class ArchivedPollItemViewModel
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public DateTime ArchivedDate { get; set; }
    }
}
