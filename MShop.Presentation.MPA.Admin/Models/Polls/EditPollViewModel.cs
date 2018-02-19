using System;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Polls
{
	public class EditPollViewModel
	{
		public Guid Id { get; set; }
		public string AddedDate { get; set; }
		public string AddedBy { get; set; }
		public int Votes { get; set; }
		[Required]
		public string QuestionText { get; set; }
		public bool IsCurrent { get; set; }
	}
}

