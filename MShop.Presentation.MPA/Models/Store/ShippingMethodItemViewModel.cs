
using System;

namespace MShop.Presentation.MPA.Public.Models.Store {
    public class ShippingMethodItemViewModel
    {
        public Guid ShippingMethodId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
