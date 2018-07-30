
using System;
using System.Collections.Generic;

namespace MShop.ViewComponents.Models
{
	public class PollViewModel
	{
		public Guid Id { get; set; }
		public bool ShowArchiveLink { get; set; }
		public bool ShowHeader { get; set; }
		public string QuestionText { get; set; }
		public string HeaderText { get; set; }
		public Guid SelectedOptionId { get; set; }
		public List<OptionViewModel> Options { get; set; } = new List<OptionViewModel>();
		public string Congratulation { get; set; }
		public bool IsPostBack { get; set; }
		public bool ShowPoll { get; set; } = true;
	}
}
