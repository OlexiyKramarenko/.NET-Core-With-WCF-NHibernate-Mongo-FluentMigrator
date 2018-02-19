using System;

namespace MShop.ViewComponents.Models
{
    public class ProductItemViewModel
    {
		public Guid Id { get; set; }
		public string ImageUrl { get; set; }       
        public int AverageRating { get; set; }
        public string Title { get; set; }
        public int Votes { get; set; }
        public int UnitsInStock { get; set; }
        public int DiscountPercentage { get; set; }
        public int UnitPrice { get; set; }
        public int FinalUnitPrice { get; set; }
    }
}
