using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.Presentation.MPA.Admin.Models.Polls;
using IPollsRepository = MShop.DataLayer.Repositories.IPollsRepository<
	MShop.DataLayer.EF.Entities.Polls.Poll,
	MShop.DataLayer.EF.Entities.Polls.PollOption, System.Guid>;

namespace MShop.Presentation.MPA.Admin.Controllers
{
	public class ManagePollsController : Controller
	{
		private readonly IPollsRepository _pollsRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ManagePollsController(IPollsRepository pollsRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_pollsRepository = pollsRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		
		#region Options

		[HttpGet]
		public IActionResult ManageOptions(Guid id)
		{
			try
			{
				List<PollOption> options = _pollsRepository.GetOptions(id);
				var model = _mapper.Map<IEnumerable<OptionItemViewModel>>(options);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditOption(Guid id)
		{
			try
			{
				PollOption option = _pollsRepository.GetOptionById(id);
				var model = _mapper.Map<EditOptionViewModel>(option);
				return View(model);
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public IActionResult DeleteOption(Guid id)
		{
			try
			{
				_pollsRepository.DeleteOption(id);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageOptions));
			}
			catch
			{
				return View();
			}
		}
		[HttpPut]
		public IActionResult EditOption(EditOptionViewModel model)
		{
			try
			{
				_pollsRepository.UpdateOption(model.Id, model.OptionText);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageOptions));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddOption()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddOption(AddOptionViewModel model)
		{
			try
			{
				var option = _mapper.Map<PollOption>(model);
				_pollsRepository.InsertOption(option);
				_unitOfWork.Commit();
				return RedirectToAction(nameof(this.ManageOptions));
			}
			catch
			{
				return View();
			}
		}
		#endregion

		#region Polls

		[HttpGet]
		public IActionResult ManagePolls(bool includeActive, bool includeArchived)
		{
			try
			{
				List<Poll> polls = _pollsRepository.GetPolls(includeActive, includeArchived);
				var model = _mapper.Map<List<PollItemViewModel>>(polls);
				return View(model);
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult DeletePoll(Guid id)
		{
			try
			{
				_pollsRepository.DeletePoll(id);
				_unitOfWork.Commit();
				return View(nameof(this.ManagePolls));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult AddPoll()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddPoll(AddPollViewModel model)
		{
			try
			{
				var poll = _mapper.Map<Poll>(model);
				_pollsRepository.InsertPoll(poll);
				_unitOfWork.Commit();
				return View(nameof(this.ManagePolls));
			}
			catch
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult EditPoll(Guid id)
		{
			Poll poll = _pollsRepository.GetPollWithVotesById(id);
			var model = _mapper.Map<EditPollViewModel>(poll);
			return View(model);
		}

		[HttpPut]
		public IActionResult EditPoll(EditPollViewModel model)
		{
			try
			{
				var poll = _mapper.Map<Poll>(model);
				_pollsRepository.UpdatePoll(model.Id, model.QuestionText, model.IsCurrent);
				_unitOfWork.Commit();
				return View(nameof(this.ManagePolls));
			}
			catch
			{
				return View();
			}
		}
		#endregion
	}
}
