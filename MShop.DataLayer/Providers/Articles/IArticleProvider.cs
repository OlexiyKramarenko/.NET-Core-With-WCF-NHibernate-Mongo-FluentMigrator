
using MShop.DataLayer.Entities.Articles;

namespace MShop.DataLayer.Providers.Articles
{
	public interface IArticleProvider : IArticle
	{
		string CategoryTitle { get; set; }
	}
}
