using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace MShop.Presentation.MPA.Public.Models.Store
{
    public class ShippingAddressViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public string Phone { get; set; }
    }
}
