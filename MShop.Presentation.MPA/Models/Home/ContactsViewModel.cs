
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Public.Models.Home
{
    public class ContactsViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
