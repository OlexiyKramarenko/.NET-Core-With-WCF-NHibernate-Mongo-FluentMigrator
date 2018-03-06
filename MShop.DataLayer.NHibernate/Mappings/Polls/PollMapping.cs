using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Polls;
using System.Collections.Generic;

namespace MShop.DataLayer.NHibernate.Mappings.Polls
{
	public class PollMapping : ClassMap<Poll>
	{
		public PollMapping()
		{
			Table("Polls");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.QuestionText);
			Map(m => m.IsCurrent);
			Map(m => m.Votes);
			Map(m => m.ArchivedDate);
			HasMany(x => (List<PollOption>)x.PollOptions).KeyColumn("Id");
		}
	}
}
