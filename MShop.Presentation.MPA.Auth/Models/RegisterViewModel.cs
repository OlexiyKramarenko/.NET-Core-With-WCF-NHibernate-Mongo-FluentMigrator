
using System.ComponentModel.DataAnnotations; 

namespace MShop.Presentation.MPA.Auth.Models
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Год рождения")]
		public int Year { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		[DataType(DataType.Password)]
		[Display(Name = "Подтвердить пароль")]
		public string PasswordConfirm { get; set; }
	}
	//public class RegisterViewModel
	//   {
	//       [Required]
	//       public string UserName { get; set; }
	//       [Required]
	//       [MinLength(5)]
	//       [RegularExpression(@"\w{5,}",ErrorMessage = "Password must be at least 5 characters long.")]
	//       public string Password { get; set; }
	//       [Required]
	//       [CompareAttribute("NewPassword", ErrorMessage = "The Password and Confirmation Password must match.")]
	//       public string ConfirmPassword { get; set; }
	//       [Required]
	//       [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
	//       public string Email { get; set; }
	//       [Required]
	//       public string Question { get; set; }
	//       public string Answer { get; set; }

	//   }
}
