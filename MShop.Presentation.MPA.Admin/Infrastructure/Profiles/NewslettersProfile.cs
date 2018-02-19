using AutoMapper;
using MShop.DataLayer.EF.Entities.Newsletters; 
using MShop.Presentation.MPA.Admin.Models.Newsletters;

namespace MShop.Presentation.MPA.Admin.Infrastructure.Profiles
{
    public class NewslettersProfile : Profile
    {
        public NewslettersProfile()
        {
            CreateMap<SendNewsletterViewModel,Newsletter>();
        }
    }
}
