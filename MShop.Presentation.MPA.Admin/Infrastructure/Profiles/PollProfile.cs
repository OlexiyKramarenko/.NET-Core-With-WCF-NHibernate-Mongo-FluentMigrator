using AutoMapper;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.Presentation.MPA.Admin.Models.Polls;
using MShop.ViewComponents.Models;

namespace MShop.Presentation.MPA.Admin.Infrastructure.Profiles
{
    public class PollProfile : Profile
	{
		public PollProfile()
		{
			CreateMap<Poll, PollItemViewModel>();
			CreateMap<Poll, EditPollViewModel>().ReverseMap();
			CreateMap<PollOption, OptionItemViewModel>();
			CreateMap<Poll, PollViewModel>();
			CreateMap<PollOption, OptionViewModel>();
		}
    }
}
