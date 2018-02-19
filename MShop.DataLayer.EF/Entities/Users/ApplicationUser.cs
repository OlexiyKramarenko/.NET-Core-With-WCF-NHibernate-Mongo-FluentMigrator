

using Microsoft.AspNetCore.Identity;
using MShop.DataLayer.Entities.Users;

namespace MShop.DataLayer.EF.Entities.Users
{
	public class ApplicationUser : IdentityUser, IApplicationUser
	{
		public int Year { get; set; }
	}
}
