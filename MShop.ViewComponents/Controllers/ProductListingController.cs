
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.Repositories;

namespace MShop.ViewComponents.Controllers
{
	public class ProductListingController : Controller
	{
		private readonly IStoreRepository _storeRepository;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public ProductListingController(IStoreRepository storeRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_storeRepository = storeRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			_storeRepository.DeleteProduct(id);
			_unitOfWork.Commit();
			return View();
		}  
	}
}
