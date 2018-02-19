
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Newsletters
{
    public class SendNewsletterViewModel
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string PlainTextBody { get; set; }
        public string HtmlBody { get; set; }
    }
}
