
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.Providers.Forum;

namespace MShop.DataLayer.EF.Providers.Forum
{
	public class PostProvider : Post, IPostProvider
	{
		public string ForumTitle { get; set; }
	}
}
