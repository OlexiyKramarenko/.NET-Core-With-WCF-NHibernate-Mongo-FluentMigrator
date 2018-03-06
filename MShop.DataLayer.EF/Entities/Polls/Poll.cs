using MShop.DataLayer.Entities.Polls;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.EF.Entities.Polls
{
	public class Poll : IPoll
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string QuestionText { get; set; }
		public bool IsCurrent { get; set; }
		public bool IsArchived { get; set; }
		public int Votes { get; set; }
		public DateTime? ArchivedDate { get; set; }
		public IList<IPollOption> PollOptions { get; set; }		
	}
}
