
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.Presentation.MPA.Public.Models.Polls;
using MShop.ViewComponents.Models;
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
		private IHttpContextAccessor _accessor;
		public PollsController(IPollsRepository pollsRepository, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor)
		{
			_accessor = accessor;
			_pollsRepository = pollsRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		
		[HttpPost]
		public IActionResult PollResult(PollViewModel model)
		{
			string userIp = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
			_pollsRepository.InsertVote(model.SelectedOptionId, model.Id, userIp);
			_unitOfWork.Commit();
			
			Poll poll = _pollsRepository.GetPollById(model.Id);
			List<PollOption> options = _pollsRepository.GetOptions(model.Id);
			int totalVotes = options.Sum(o => o.Votes);

			var pollResult = new PollResultViewModel
			{
				QuestionText = poll.QuestionText,
				TotalVotes = totalVotes,
				Items = options.Select(option => new PollResultItemViewModel
				{
					AnswerText = option.OptionText,
					Votes = option.Votes,
					Percentage = Math.Round((double)100 / totalVotes * option.Votes, 1)
				})
			};

			ViewBag.IsPostBack = true;
			
			return View(pollResult);
		}
	}
}