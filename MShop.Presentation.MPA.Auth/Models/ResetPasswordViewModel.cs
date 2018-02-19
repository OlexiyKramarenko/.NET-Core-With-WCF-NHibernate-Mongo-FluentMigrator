
namespace MShop.Presentation.MPA.Auth.Models
{
	public class ResetPasswordViewModel
	{
		public string Email { get; internal set; }
		public string Code { get; internal set; }
		public string Password { get; internal set; }
	}
}
