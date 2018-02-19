
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MShop.Presentation.MPA.Admin.Models.Store
{
    public class ManageOrdersViewModel
    {
        public List<SelectListItem> Statuses { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime FromDate { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime ToDate { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Guid StatusId { get; set; }
    }
}
