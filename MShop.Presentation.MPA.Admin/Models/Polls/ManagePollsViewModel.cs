using MShop.ViewComponents.Models;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Admin.Models.Polls
{
    public class ManagePollsViewModel
    {
		public PagerViewModel Pager { get; set; }
		public IEnumerable<PollItemViewModel> PollItems { get; set; }
	}
}
