
using MShop.DataLayer.Mongo.Entities.Forums;
using MShop.DataLayer.Providers.Forum;

namespace MShop.DataLayer.Mongo.Providers.Forum
{
	public class PostProvider : Post, IPostProvider
	{
		public string ForumTitle { get; set; }
	}
}
