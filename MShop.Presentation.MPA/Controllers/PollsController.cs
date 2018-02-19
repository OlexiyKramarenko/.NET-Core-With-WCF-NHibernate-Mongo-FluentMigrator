
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.Presentation.MPA.Public.Models.Polls;
using IPollsRepository = MShop.DataLayer.Repositories.IPollsRepository<
	MShop.DataLayer.EF.Entities.Polls.Poll,
	MShop.DataLayer.EF.Entities.Polls.PollOption, System.Guid>;

namespace MShop.Presentation.MPA.Public.Controllers
{
	public class PollsController : Controller
	{
		private readonly IPollsRepository _pollsRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public PollsController(IPollsRepository pollsRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_pollsRepository = pollsRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;

			//List<PollOption> options = _pollsRepository.GetOptions(id);
			//PollOption option = _pollsRepository.GetOptionById(id);
			//Poll poll = _pollsRepository.GetPollWithVotesById(id);
			//List<Poll> polls = _pollsRepository.GetPolls(false, false);
			//int pollId = _pollsRepository.GetCurrentPollId();
		}

		[HttpGet]
		public IActionResult ArchivedPolls(bool includeActive, bool includeArchived)
		{
			try
			{
				List<Poll> polls = _pollsRepository.GetPolls(includeActive, includeArchived);
				List<ArchivedPollItemViewModel> model = _mapper.Map<List<Poll>, List<ArchivedPollItemViewModel>>(polls);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpDelete]
		public IActionResult DeletePoll(Guid id)
		{
			try
			{
				_pollsRepository.DeletePoll(id);
				_unitOfWork.Commit();
				return View(nameof(this.ArchivedPolls));
			}
			catch
			{
				return View();
			}
		}
	}
}
