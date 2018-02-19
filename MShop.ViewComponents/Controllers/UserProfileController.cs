using MShop.DataLayer.Repositories; 
using AutoMapper;

namespace MShop.ViewComponents.Controllers
{
    class UserProfileController
	{
		private readonly IUsersRepository _usersRepository;
		private readonly IMapper _mapper;

		public UserProfileController(IUsersRepository usersRepository, IMapper mapper)
		{
			_usersRepository = usersRepository;
			_mapper = mapper;
		}

		//private object SaveProfile()
		//{
		//	return null;
		//} 
	}
}
