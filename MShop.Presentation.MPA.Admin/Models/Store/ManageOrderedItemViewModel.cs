
using System;

namespace MShop.Presentation.MPA.Admin.Models.Store
{
    public class ManageOrderedItemViewModel
    {
        public string SKU { get; set; }
        public string Title { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
