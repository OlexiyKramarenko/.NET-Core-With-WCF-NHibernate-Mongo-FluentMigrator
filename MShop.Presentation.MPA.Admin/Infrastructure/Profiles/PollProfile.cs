using AutoMapper;
using MShop.DataLayer.EF.Entities.Polls;
using MShop.Presentation.MPA.Admin.Models.Polls;

namespace MShop.Presentation.MPA.Admin.Infrastructure.Profiles
{
    public class PollProfile : Profile
	{
		public PollProfile()
		{
			CreateMap<Poll, PollItemViewModel>();
			CreateMap<Poll, EditPollViewModel>().ReverseMap();
			CreateMap<PollOption, OptionItemViewModel>();
		}
    }
}
