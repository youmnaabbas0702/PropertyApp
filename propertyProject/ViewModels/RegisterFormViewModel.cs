using Microsoft.AspNetCore.Mvc.Rendering;
using propertyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace propertyProject.ViewModels
{
    public class RegisterFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name should'nt be less than 3 characters.")]
        [MaxLength(30, ErrorMessage = "Name should'nt be more than 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!@#$%^&*()_+[\]{}|\\,.?:\-\/]{8,}$", ErrorMessage = "Password should be at least 8 characters long and contain at least 1 letter and 1 number.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
