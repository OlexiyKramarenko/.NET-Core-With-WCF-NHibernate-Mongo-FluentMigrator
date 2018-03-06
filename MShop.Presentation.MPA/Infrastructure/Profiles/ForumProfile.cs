using AutoMapper;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Providers.Forum;
using MShop.Presentation.MPA.Public.Models.Forums;

namespace MShop.Presentation.MPA.Public.Infrastructure.Profiles
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<PostProvider, ThreadItemViewModel>();
            CreateMap<Forum, ForumItemViewModel>();
            CreateMap<PostProvider, PostItemViewModel>();
            CreateMap<AddPostViewModel, Post>();
            CreateMap<Post, EditPostViewModel>();
			CreateMap<EditPostViewModel, Post>();
			CreateMap<Forum, ForumItemViewModel>();
		}
    }
}
