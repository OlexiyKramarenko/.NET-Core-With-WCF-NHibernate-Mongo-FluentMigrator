using AutoMapper;
using MShop.DataLayer.Entities.Polls;
using MShop.ViewComponents.Models; 

namespace MShop.ViewComponents.Infrastructure
{
	public class PollsProfile : Profile
	{
		public PollsProfile()
		{
			CreateMap<IPollOption, OptionViewModel>();
		}
	}
}
