 
using MShop.DataLayer.NHibernate.Entities.Articles;
using MShop.DataLayer.Providers.Articles;

namespace MShop.DataLayer.NHibernate.Providers.Articles
{
    public class CommentProvider : Comment, ICommentProvider
	{
        public string ArticleTitle { get; set; }
    }
}
