using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Store
{
	public class ManageOrderItemViewModel
	{
		public Guid Id { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime Date { get; set; }
		public string Customer { get; set; }
		public int Subtotal { get; set; }
		public string Shipping { get; set; }
		public IEnumerable<ManageOrderedItemViewModel> Items { get; set; } = new List<ManageOrderedItemViewModel>();
	}
}
