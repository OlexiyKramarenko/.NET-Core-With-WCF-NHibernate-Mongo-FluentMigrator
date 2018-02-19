 
using MShop.DataLayer.NHibernate.Entities.Store;

namespace MShop.DataLayer.Providers.Store
{
    public class ProductProvider : Product, IProductProvider
	{
        public string DepartmentTitle { get; set; }
    }
}
