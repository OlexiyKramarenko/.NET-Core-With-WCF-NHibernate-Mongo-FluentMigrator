using AutoMapper;
using MShop.DataLayer.EF.Entities.Newsletters;
using MShop.DataLayer.Entities.Newsletters;
using MShop.Presentation.MPA.Public.Models.Newsletters;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Infrastructure.Profiles
{
    public class NewslettersProfile : Profile
    {
        public NewslettersProfile()
        {
            CreateMap<List<Newsletter>, List<NewsletterItemViewModel>>();
            CreateMap<Newsletter, NewsletterViewModel>();
        }
    }
}
