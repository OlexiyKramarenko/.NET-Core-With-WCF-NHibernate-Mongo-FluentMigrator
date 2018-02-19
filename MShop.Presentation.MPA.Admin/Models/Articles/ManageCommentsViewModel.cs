using MShop.ViewComponents.Models;
using System;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Admin.Models.Articles
{
    public class ManageCommentsViewModel
    {
		public PagerViewModel Pager { get; set; }
		public IEnumerable<ManageCommentItemViewModel> CommentItems { get; set; }
	}
}
