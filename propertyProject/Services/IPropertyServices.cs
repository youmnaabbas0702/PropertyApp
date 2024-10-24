using propertyProject.Models;

namespace propertyProject.Services
{
    public interface IPropertyServices
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(int cityId, string genderFilter, string sortOrder);
        Task<IEnumerable<Property>> GetPropertisForUserAsync(int userCity, Gender userGender, string sortOrder);
        Task<Property?> GetPropertyByIdAsync(int id);
        Task AddPropertyAsync(AddPropertyFormViewModel model, int adminId);
        Task UpdatePropertyAsync(EditPropertyFormViewModel model);
        Task DeletePropertyAsync(int id);
        AddPropertyFormViewModel GetAddFormViewModel();
        EditPropertyFormViewModel GetEditFormViewModel(int id, Property property, List<int> servicesIds);
        IEnumerable<SelectListItem> GetGendersList();
        IEnumerable<SelectListItem> GetAvailableServicesList();
    }
}
