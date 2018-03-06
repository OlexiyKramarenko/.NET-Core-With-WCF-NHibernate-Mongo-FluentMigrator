using FluentNHibernate.Mapping;
using MShop.DataLayer.NHibernate.Entities.Newsletters;

namespace MShop.DataLayer.NHibernate.Mappings.Newsletters
{
	public class NewsletterMapping : ClassMap<Newsletter>
	{
		public NewsletterMapping()
		{
			Table("Newsletters");
			Id(m => m.Id);
			Map(m => m.AddedDate);
			Map(m => m.AddedBy);
			Map(m => m.Subject);
			Map(m => m.PlainTextBody);
			Map(m => m.HtmlBody);
		}
	}
}
