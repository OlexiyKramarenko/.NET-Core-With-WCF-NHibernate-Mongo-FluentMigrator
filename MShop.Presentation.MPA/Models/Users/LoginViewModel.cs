﻿namespace MShop.Presentation.MPA.Public.Models.Users
{
	public class LoginViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
		public string ReturnUrl { get; set; }
	}
}
