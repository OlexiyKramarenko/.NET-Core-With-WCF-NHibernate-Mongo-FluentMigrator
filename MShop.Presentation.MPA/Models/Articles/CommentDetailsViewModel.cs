
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Public.Models.Articles
{
    public class CommentDetailsViewModel
    {
        [Required]
        public string AddedBy { get; set; }
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string AddedByEmail { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
