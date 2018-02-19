using MShop.DataLayer.Entities.Polls;
using System;

namespace MShop.DataLayer.EF.Entities.Polls
{
    public class PollOption: IPollOption
	{
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public Guid PollId { get; set; }
        public string OptionText { get; set; }
        public int Votes { get; set; }
        public double Percentage { get; set; }
        public Poll Poll { get; set; }
    }
}
