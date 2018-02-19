
using MShop.DataLayer.EF.Entities.Articles;
using MShop.DataLayer.Providers.Articles;

namespace MShop.DataLayer.EF.Providers.Articles
{
    public class CommentProvider : Comment, ICommentProvider
	{
        public string ArticleTitle { get; set; }
    }
}
