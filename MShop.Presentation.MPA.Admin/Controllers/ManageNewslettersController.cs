
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer; 
using MShop.Presentation.MPA.Admin.Models.Newsletters;
using System;
using INewslettersRepository = MShop.DataLayer.Repositories.INewslettersRepository<MShop.DataLayer.EF.Entities.Newsletters.Newsletter, System.Guid>;


namespace MShop.Presentation.MPA.Admin.Controllers
{
	public class ManageNewslettersController : Controller
	{
		private readonly INewslettersRepository _newslettersRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ManageNewslettersController(INewslettersRepository newslettersRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_newslettersRepository = newslettersRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		
		[HttpGet]
		public IActionResult SendNewsletter()
		{

			return View();
		}

		[HttpPost]
		public IActionResult SendNewsletter(SendNewsletterViewModel model)
		{

			return View();
		}
		
	}
}
