using MShop.DataLayer.Entities.Polls;
using System;

namespace MShop.DataLayer.NHibernate.Entities.Polls
{
	public class PollOption : IPollOption
	{
		public virtual Guid Id { get; set; }
		public virtual DateTime AddedDate { get; set; }
		public virtual string AddedBy { get; set; }
		public virtual Guid PollId { get; set; }
		public virtual string OptionText { get; set; }
		public virtual int Votes { get; set; }
		public virtual double Percentage { get; set; }
		public virtual Poll Poll { get; set; }
	}
}
