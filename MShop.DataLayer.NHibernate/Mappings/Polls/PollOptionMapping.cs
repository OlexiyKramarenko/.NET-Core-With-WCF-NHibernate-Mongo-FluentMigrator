using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Polls;

namespace MShop.DataLayer.NHibernate.Mappings.Polls
{
	public class PollOptionMapping : ClassMap<PollOption>
	{
		public PollOptionMapping()
		{
			Table("PollOptions");
			Id(m => m.Id);			
			Map(m => m.AddedDate);
			Map(m => m.AddedBy); 
			Map(m => m.OptionText);
			Map(m => m.Votes);
			Map(m => m.Percentage);
			References(m => (Poll)m.Poll, "PollId");
		}
	}
}
