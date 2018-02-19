 
using MShop.DataLayer.NHibernate.Entities.Forums;
using MShop.DataLayer.Providers.Forum;

namespace MShop.DataLayer.NHibernate.Providers.Forum
{
	public class PostProvider : Post, IPostProvider
	{
		public string ForumTitle { get; set; }
	}
}
