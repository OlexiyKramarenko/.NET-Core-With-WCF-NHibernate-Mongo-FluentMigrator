using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IUsersRepository = MShop.DataLayer.Repositories.IUsersRepository<MShop.DataLayer.Entities.Users.IApplicationUser>;

namespace MShop.ViewComponents.Components.Users
{
	public class UserProfileViewComponent : ViewComponent
	{
		private readonly IUsersRepository _usersRepository;
		private readonly IMapper _mapper;

		public UserProfileViewComponent(IUsersRepository usersRepository, IMapper mapper)
		{
			_usersRepository = usersRepository;
			_mapper = mapper;
		}
		public IViewComponentResult Invoke()
		{
			return View();
		}		
	}
}
