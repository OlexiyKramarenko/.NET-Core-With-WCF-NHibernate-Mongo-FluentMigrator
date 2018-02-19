using MShop.DataLayer.EF.Entities.Store;
using MShop.DataLayer.Providers.Store;

namespace MShop.DataLayer.EF.Providers.Store
{
	public class OrderProvider : Order, IOrderProvider
	{
		public string StatusTitle { get; set; }
	}
}
