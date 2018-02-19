 
using MShop.DataLayer.NHibernate.Entities.Articles;
using MShop.DataLayer.Providers.Articles;

namespace MShop.DataLayer.NHibernate.Providers.Articles
{
    public class ArticleProvider : Article, IArticleProvider
	{
        public string CategoryTitle { get; set; }
    }
}
