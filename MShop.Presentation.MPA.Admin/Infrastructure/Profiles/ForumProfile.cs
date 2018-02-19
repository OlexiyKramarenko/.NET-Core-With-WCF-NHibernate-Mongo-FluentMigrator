using AutoMapper;
using MShop.DataLayer.EF.Entities.Forums;
using MShop.DataLayer.EF.Providers.Forum; 
using MShop.Presentation.MPA.Admin.Models.Forums; 

namespace MShop.Presentation.MPA.Admin.Infrastructure.Profiles
{
	public class ForumProfile : Profile
	{
		public ForumProfile()
		{
			CreateMap<Forum, ManageForumItemViewModel>();
			CreateMap<Forum, ManageForumItemViewModel>();
			CreateMap<AddForumViewModel, Forum>();
			CreateMap<Forum, EditForumViewModel>();
			CreateMap<EditForumViewModel, Forum>();
			CreateMap<PostProvider, ThreadViewModel>();
			CreateMap<PostProvider, PostViewModel>();
			CreateMap<PostProvider, UnapprovedPostItemViewModel>();
		}
	}
}
