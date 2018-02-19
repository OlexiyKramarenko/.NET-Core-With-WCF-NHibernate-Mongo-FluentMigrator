using MShop.DataLayer.Entities.Store;

namespace MShop.DataLayer.Providers.Store
{
	public interface IOrderProvider : IOrder
	{
		string StatusTitle { get; set; }
	}
}
