using MShop.DataLayer.EF.Entities.Users;
using MShop.ViewComponents.Models; 
using System.Collections.Generic; 

namespace MShop.Presentation.MPA.Admin.Models.Users
{
	public class ManageUsersViewModel
	{
		public PagerViewModel Pager { get; set; }
		public IEnumerable<ApplicationUser> Users { get; set; }
	}
}
