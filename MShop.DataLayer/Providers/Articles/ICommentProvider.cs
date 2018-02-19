
using MShop.DataLayer.Entities.Articles;

namespace MShop.DataLayer.Providers.Articles
{
	public interface ICommentProvider : IComment
	{
		string ArticleTitle { get; set; }
	}
}
