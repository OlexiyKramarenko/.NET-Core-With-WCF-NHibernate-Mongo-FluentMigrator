using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.ViewComponents.Models;
using System;
using IPollsRepository = MShop.DataLayer.Repositories.IPollsRepository<
	MShop.DataLayer.EF.Entities.Polls.Poll,
	MShop.DataLayer.EF.Entities.Polls.PollOption, System.Guid>;

namespace MShop.ViewComponents.Components.Polls
{
	public class PollBoxViewComponent : ViewComponent
	{
		private readonly IPollsRepository _pollsRepository;
		private readonly IMapper _mapper;

		public PollBoxViewComponent(IPollsRepository pollsRepository, IMapper mapper)
		{
			_pollsRepository = pollsRepository;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke(Guid pollId, bool showHeader, bool showQuestion, bool showArchiveLink)
		{
			Poll poll = _pollsRepository.GetPollWithVotesById(pollId);
			PollBoxViewModel model = _mapper.Map<Poll, PollBoxViewModel>(poll);
			return View(model);
		}
		
	}
}
