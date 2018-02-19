
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Users
{
    public class EditUserViewModel
    {
        List<string> AllRoles { get; set; }
        List<string> SelectedRoles { get; set; } 

		public string Id { get; set; }
		public string Email { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime BirthDate { get; set; }
	}
}
