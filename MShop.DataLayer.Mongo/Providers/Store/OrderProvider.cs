using MShop.DataLayer.Mongo.Entities.Store;
using MShop.DataLayer.Providers.Store;

namespace MShop.DataLayer.Mongo.Providers.Store
{
	public class OrderProvider : Order, IOrderProvider
	{
		public string StatusTitle { get; set; }
	}
}
