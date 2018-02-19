using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IStoreRepository = MShop.DataLayer.Repositories.IStoreRepository<
	MShop.DataLayer.EF.Entities.Store.Department,
	MShop.DataLayer.EF.Entities.Store.OrderStatus,
	MShop.DataLayer.EF.Entities.Store.ShippingMethod,
	MShop.DataLayer.EF.Entities.Store.Product,
	MShop.DataLayer.EF.Entities.Store.Order,
	MShop.DataLayer.EF.Entities.Store.OrderItem,
	MShop.DataLayer.EF.Providers.Store.OrderProvider,
	MShop.DataLayer.Providers.Store.ProductProvider, System.Guid>;

namespace MShop.ViewComponents.Components.Store
{
	public class ShoppingCartBoxViewComponent : ViewComponent
	{
		private readonly IStoreRepository _storeRepository;
		private readonly IMapper _mapper;

		public ShoppingCartBoxViewComponent(IStoreRepository storeRepository, IMapper mapper)
		{
			_storeRepository = storeRepository;
			_mapper = mapper;
		}
		public IViewComponentResult Invoke()
		{
			//List<OrderItemViewModel> list = new List<OrderItemViewModel>();
			//return View(list);
			return View();
		}

	}
}
