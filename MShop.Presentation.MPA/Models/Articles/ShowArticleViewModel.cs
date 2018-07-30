using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Models.Articles
{
	public class ShowArticleViewModel
	{		
		public List<CommentItemViewModel> Comments { get; set; } = new List<CommentItemViewModel>();
		public CommentDetailsViewModel PostComment { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
	}
}
