using System;

namespace MShop.DataLayer.Entities.Newsletters
{
	public interface INewsletter
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Subject { get; set; }
		string PlainTextBody { get; set; }
		string HtmlBody { get; set; }
	}
}
