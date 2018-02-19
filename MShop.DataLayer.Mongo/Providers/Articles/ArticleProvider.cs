 
using MShop.DataLayer.Mongo.Entities.Articles;
using MShop.DataLayer.Providers.Articles;

namespace MShop.DataLayer.Mongo.Providers.Articles
{
    public class ArticleProvider : Article, IArticleProvider
	{
        public string CategoryTitle { get; set; }
    }
}
