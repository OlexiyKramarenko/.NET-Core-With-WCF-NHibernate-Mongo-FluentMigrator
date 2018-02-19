using AutoMapper;
using MShop.DataLayer.EF.Entities.Articles; 
using MShop.Presentation.MPA.Public.Models.Articles;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Infrastructure.Profiles
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            CreateMap<IList<Category>, List<CategoryItemViewModel>>();
             
        }
    }
}
