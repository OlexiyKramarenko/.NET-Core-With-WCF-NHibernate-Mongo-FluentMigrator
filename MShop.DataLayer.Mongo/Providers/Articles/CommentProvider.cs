
using MShop.DataLayer.Mongo.Entities.Articles;
using MShop.DataLayer.Providers.Articles;

namespace MShop.DataLayer.Mongo.Providers.Articles
{
    public class CommentProvider : Comment, ICommentProvider
	{
        public string ArticleTitle { get; set; }
    }
}
