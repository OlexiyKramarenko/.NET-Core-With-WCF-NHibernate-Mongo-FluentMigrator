
using System.Collections.Generic;
using MShop.DataLayer.Entities.Users;

namespace MShop.DataLayer.Repositories
{
	public interface IUsersRepository<T> where T : IApplicationUser
	{
		List<T> GetAllUsers();
		T GetUserByEmail(string email);
		T GetUserByName(string userName);
		void DeleteUser(string userName);
	}
}
