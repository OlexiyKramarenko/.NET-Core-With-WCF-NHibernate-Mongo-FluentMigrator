using MShop.DataLayer.Entities.Users;

namespace MShop.DataLayer.NHibernate.Entities.Users
{
	public class ApplicationUser : IApplicationUser
	{
		public virtual int Year { get; set; }
		public virtual string Email { get; set; }
		public virtual bool EmailConfirmed { get; set; }
		public virtual string PasswordHash { get; set; }
		public virtual string SecurityStamp { get; set; }
		public virtual string PhoneNumber { get; set; }
		public virtual bool PhoneNumberConfirmed { get; set; }
		public virtual bool TwoFactorEnabled { get; set; }
		public virtual bool LockoutEnabled { get; set; }
		public virtual int AccessFailedCount { get; set; }
		public virtual string UserName { get; set; }
	}
}
