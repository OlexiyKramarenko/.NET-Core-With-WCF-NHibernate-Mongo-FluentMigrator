
using System;

namespace MShop.Presentation.MPA.Public.Models.Store
{
    public class ShowProductViewModel
    {
		public Guid Id { get; set; }
		public string Title { get; set; }        
        public decimal DiscountedPrice { get; set; }
        public decimal Price { get; set; }
        public int UserCount { get; set; }
        public string Description { get; set; }
    }
}
