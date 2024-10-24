using Microsoft.AspNetCore.Mvc.Rendering;
using propertyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace propertyProject.ViewModels
{
    public class EditPropertyFormViewModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[0-9]+\s+[a-zA-Z\s]+,\s+[a-zA-Z\s]+,\s+[a-zA-Z\s]+,\s+[a-zA-Z\s]+$", ErrorMessage = "Please enter the address in the right format.")]
        public string Address { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "The value must be non-negative.")]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value must be non-negative.")]
        public int RoomsAvailable { get; set; }

        [RegularExpression(@"^01[0-2]\d{1,8}$", ErrorMessage = "Please write a valid egyptian phone number.")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "description is required.")]
        [MinLength(100, ErrorMessage = "description should'nt be less than 100 characters.")]
        [MaxLength(1000, ErrorMessage = "description should'nt be more than 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<int> SelectedServiceIds { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> AvailableServices { get; set; } = new List<SelectListItem>();
    }
}
