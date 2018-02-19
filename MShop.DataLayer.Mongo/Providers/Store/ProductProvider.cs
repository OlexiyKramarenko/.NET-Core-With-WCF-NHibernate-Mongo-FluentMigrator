using MShop.DataLayer.Mongo.Entities.Store; 

namespace MShop.DataLayer.Providers.Store
{
    public class ProductProvider : Product, IProductProvider
	{
        public string DepartmentTitle { get; set; }
    }
}
