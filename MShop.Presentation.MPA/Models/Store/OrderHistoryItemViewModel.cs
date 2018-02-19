using System;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Models.Store
{
    public class OrderHistoryItemViewModel
    {
        public Guid OrderHistoryId { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Shipping { get; set; }
        public string StatusTitle { get; set; }
        public Guid StatusId { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
    }
}
