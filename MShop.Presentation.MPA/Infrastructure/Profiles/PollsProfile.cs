using AutoMapper;
using MShop.DataLayer.EF.Entities.Polls; 
using MShop.Presentation.MPA.Public.Models.Polls;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Infrastructure.Profiles
{
    public class PollsProfile : Profile
    {
        public PollsProfile()
        {
            CreateMap<List<Poll>, List<ArchivedPollItemViewModel>>();
        }
    }
}
