using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.ViewComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using IPollsRepository = MShop.DataLayer.Repositories.IPollsRepository<
	MShop.DataLayer.EF.Entities.Polls.Poll,
	MShop.DataLayer.EF.Entities.Polls.PollOption, System.Guid>;

namespace MShop.ViewComponents.Components
{
	public class PollBoxViewComponent : ViewComponent
	{
		private readonly IPollsRepository _pollsRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private IHttpContextAccessor _accessor;

		public PollBoxViewComponent(IPollsRepository pollsRepository, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor)
		{
			_accessor = accessor;
			_pollsRepository = pollsRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke()
		{
			var model =  new PollViewModel();
			string userIp = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
			Guid pollId = _pollsRepository.GetCurrentPollId();
			bool showPoll = _pollsRepository.ShowPoll(userIp, pollId);
			if (ViewBag.IsPostBack != null)
			{
				model.IsPostBack = (bool)ViewBag.IsPostBack;
				if (model.IsPostBack)
				{
					model.Congratulation = string.Empty;
				}
				return View(model);
			}

            showPoll = true;

            if (showPoll)
			{
				Poll poll = _pollsRepository.GetPollById(pollId);
                if (poll != null)
                {
                    model = _mapper.Map<PollViewModel>(poll);
                    model.ShowPoll = true;
                    if (poll.PollOptions.Any())
                    {
                        model.Options = _mapper.Map<List<OptionViewModel>>(poll.PollOptions);
                    }
                }				
			}
			return View(model);

		}
	}
}
