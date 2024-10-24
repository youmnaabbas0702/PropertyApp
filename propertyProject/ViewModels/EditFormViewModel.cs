using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace propertyProject.ViewModels
{
    public class EditFormViewModel
    {

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name should'nt be less than 3 characters.")]
        [MaxLength(30, ErrorMessage = "Name should'nt be more than 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; } = Enumerable.Empty<SelectListItem>();

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!@#$%^&*()_+[\]{}|\\,.?:\-\/]{8,}$", ErrorMessage = "Password should be at least 8 characters long and contain at least 1 letter and 1 number.")]
        public string NewPassword { get; set; } = string.Empty;

        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}

