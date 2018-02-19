
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Newsletters;
using MShop.Presentation.MPA.Public.Models.Newsletters;
using INewslettersRepository =
	MShop.DataLayer.Repositories.INewslettersRepository<MShop.DataLayer.EF.Entities.Newsletters.Newsletter, System.Guid>;

namespace MShop.Presentation.MPA.Public.Controllers
{
    public class NewslettersController:Controller
    {
        private readonly INewslettersRepository _newslettersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewslettersController(INewslettersRepository newslettersRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _newslettersRepository = newslettersRepository;
            _unitOfWork = unitOfWork;
			_mapper = mapper;
		}

	    [HttpGet]
	    public IActionResult ArchivedNewsletters(DateTime toDate)
	    {
		    List<Newsletter> newsletters = _newslettersRepository.GetNewsletters(toDate);
		    List<NewsletterItemViewModel> model =
			    _mapper.Map<List<Newsletter>, List<NewsletterItemViewModel>>(newsletters);
		    return View(model);
	    }

	    [HttpGet]
	    public IActionResult ShowNewsletter(Guid id)
	    {
		    Newsletter newsletter = _newslettersRepository.GetNewsletterById(id);
		    NewsletterViewModel model =
			    _mapper.Map<Newsletter, NewsletterViewModel>(newsletter);
		    return View(model);
	    }
		[HttpGet]
		public IActionResult DeleteNewsletter(Guid id)
		{
			return View();
		}
	}
}
