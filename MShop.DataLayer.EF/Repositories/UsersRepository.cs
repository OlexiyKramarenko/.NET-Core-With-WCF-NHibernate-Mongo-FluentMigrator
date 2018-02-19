using System.Collections.Generic;
using System.Linq; 
using MShop.DataLayer.EF.Entities.Users; 
using MShop.DataLayer.Repositories;

namespace MShop.DataLayer.EF.Repositories
{
	//public class UsersRepository : IUsersRepository<ApplicationUser> //: UserManager<ApplicationUser>, IUsersRepository
	//{
	//	private readonly EfUnitOfWork _unitOfWork;

	//	public UsersRepository(EfUnitOfWork unitOfWork)
	//	{
	//		_unitOfWork = unitOfWork;
	//	}

	//	public List<ApplicationUser> GetAllUsers()
	//	{
	//		return _unitOfWork.Context.Users.ToList();
	//	}

	//	public ApplicationUser GetUserByEmail(string email)
	//	{
	//		return _unitOfWork.Context
	//						  .Users
	//						  .SingleOrDefault(u => u.Email == email);
	//	}

	//	public ApplicationUser GetUserByName(string userName)
	//	{
	//		return _unitOfWork.Context
	//						  .Users
	//						  .SingleOrDefault(u => u.UserName == userName);
	//	}

	//	public void CreateUser(ApplicationUser appUser)
	//	{
	//		_unitOfWork.Context.Users.Add(appUser);
	//	}

	//	public void DeleteUser(string userName)
	//	{
	//		ApplicationUser user = this.GetUserByName(userName);
	//		if (user != null)
	//			_unitOfWork.Context.Users.Remove(user);
	//	}
	//}
}
