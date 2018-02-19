
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Public.Models.Store
{
    public class ShippingDetailsViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
