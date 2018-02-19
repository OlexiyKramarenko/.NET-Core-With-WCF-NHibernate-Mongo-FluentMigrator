﻿
using System;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Store
{
    public class OrderItemViewModel
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string SKU { get; set; }
        [Required]
        public int Quantity { get; set; } 
    }
}
