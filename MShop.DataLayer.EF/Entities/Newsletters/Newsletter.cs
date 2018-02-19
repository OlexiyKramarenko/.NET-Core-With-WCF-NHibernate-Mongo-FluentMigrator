using MShop.DataLayer.Entities.Newsletters;
using System;

namespace MShop.DataLayer.EF.Entities.Newsletters
{
    public class Newsletter: INewsletter
	{             
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Subject { get; set; }
        public string PlainTextBody { get; set; }
        public string HtmlBody { get; set; }
    }
}
