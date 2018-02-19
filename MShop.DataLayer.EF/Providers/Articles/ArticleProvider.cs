 
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.Providers.Articles;

namespace MShop.DataLayer.EF.Providers.Articles
{
    public class ArticleProvider : Article, IArticleProvider
	{
        public string CategoryTitle { get; set; }
    }
}
