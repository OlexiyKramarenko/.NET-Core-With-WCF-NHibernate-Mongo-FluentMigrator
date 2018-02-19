
using MShop.DataLayer.Entities.Forums;

namespace MShop.DataLayer.Providers.Forum
{
	public interface IPostProvider : IPost
	{
		string ForumTitle { get; set; }
	}
}
