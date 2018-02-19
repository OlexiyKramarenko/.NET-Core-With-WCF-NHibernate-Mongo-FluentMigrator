using  System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MShop.Presentation.MPA.Auth.Models
{
	public class UserProfileViewModel
	{
		public List<SelectListItem> Subscriptions { get; set; }
		public List<SelectListItem> Languages { get; set; }
		public string AvatarUrl { get; set; }
		public string Signature { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<SelectListItem> Genders { get; set; }
		public DateTime BirthDate { get; set; }
		public List<SelectListItem> Occupations { get; set; }
		public string Street { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public List<SelectListItem> Countries { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
	}
}
