using AutoMapper;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Providers.Forum;
using MShop.DataLayer.Entities.Forums;
using MShop.Presentation.MPA.Public.Models.Articles;
using MShop.Presentation.MPA.Public.Models.Forums;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Public.Infrastructure.Profiles
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<List<PostProvider>, List<ThreadItemViewModel>>();
            CreateMap<List<Forum>, List<ForumItemViewModel>>();
            CreateMap<List<PostProvider>, List<PostItemViewModel>>();
            CreateMap<AddPostViewModel, Post>();
            CreateMap<Post, EditPostViewModel>();
			CreateMap<EditPostViewModel, Post>();

		}
    }
}
