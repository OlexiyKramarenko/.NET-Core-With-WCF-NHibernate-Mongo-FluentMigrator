using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Models.Polls
{
	public class PollResultViewModel
	{
		public string QuestionText { get; set; }
		public IEnumerable<PollResultItemViewModel> Items { get; set; } = new List<PollResultItemViewModel>();
		public int TotalVotes { get; set; }
	}

	public class PollResultItemViewModel
	{
		public string AnswerText { get; set; }
		public int Votes { get; set; }
		public double Percentage { get; set; }
	}
}
