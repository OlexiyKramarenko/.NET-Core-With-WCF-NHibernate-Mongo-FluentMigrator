 
using MShop.DataLayer.NHibernate.Entities.Store;
using MShop.DataLayer.Providers.Store;

namespace MShop.DataLayer.NHibernate.Providers.Store
{
	public class OrderProvider : Order, IOrderProvider
	{
		public string StatusTitle { get; set; }
	}
}
