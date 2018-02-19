using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MShop.DataLayer.Repositories;

namespace MShop.ViewComponents.Controllers
{
	public class PollBoxController : Controller
	{
		private readonly IPollsRepository _pollsRepository;
		private readonly IMapper _mapper;

		public PollBoxController(IPollsRepository pollsRepository, IMapper mapper)
		{
			_pollsRepository = pollsRepository;
			_mapper = mapper;
		}

		//Poll.CurrentPollID  Poll.GetPollByID(pollID);
	}
}
