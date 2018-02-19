
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Auth.Models
{
    public class EditProfileViewModel
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        [MinLength(5)]
        [RegularExpression(@"\w{5,}",ErrorMessage = "New Password must be at least 5 characters long.")]
        public string NewPassword { get; set; }
        [Required]
        [CompareAttribute("NewPassword", ErrorMessage = "The Confirm Password must match the New Password entry.")]
        public string ConfirmPassword { get; set; }
    }
}
