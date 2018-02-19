using MShop.DataLayer.Entities.Polls;
using System;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Entities.Polls
{
	public class Poll : IPoll
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual string QuestionText { get; set; }
		public virtual bool IsCurrent { get; set; }
		public virtual bool IsArchived { get; set; }
		public virtual int Votes { get; set; }
		public virtual DateTime? ArchivedDate { get; set; }
		public virtual List<PollOption> PollOptions { get; set; }
	}
}
