
using MShop.DataLayer.Entities.Store;

namespace MShop.DataLayer.Providers.Store
{
	public interface IProductProvider : IProduct
	{
		string DepartmentTitle { get; set; }
	}
}
