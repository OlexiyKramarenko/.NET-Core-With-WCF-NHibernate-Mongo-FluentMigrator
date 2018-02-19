
using System;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Polls
{
	public class EditOptionViewModel
	{
		public Guid Id { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public int Votes { get; set; }
		public int Percentage { get; set; }
		public string OptionText { get; set; }
	}
}
