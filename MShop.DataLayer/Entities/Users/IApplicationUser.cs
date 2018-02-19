
namespace MShop.DataLayer.Entities.Users
{
	public interface IApplicationUser
	{
		string Email { get; set; }
		bool EmailConfirmed { get; set; }
		string PasswordHash { get; set; }
		string SecurityStamp { get; set; }
		string PhoneNumber { get; set; }
		bool PhoneNumberConfirmed { get; set; }
		bool TwoFactorEnabled { get; set; }
		bool LockoutEnabled { get; set; }
		int AccessFailedCount { get; set; }
		string UserName { get; set; }
	}
}
