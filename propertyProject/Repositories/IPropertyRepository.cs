namespace propertyProject.Repositories
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(int cityId, string genderFilter, string sortOrder);
        Task<IEnumerable<Property>> GetPropertisForUserAsync(int userCity, Gender userGender, string sortOrder);
        Task<Property?> GetPropertyByIdAsync(int id);
        Task AddPropertyAsync(Property property);
        void SavePropertyImages(Image image);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int id);
        IEnumerable<SelectListItem> GetAvailableServicesList();
        Property? GetLastPropertyInCity(int cityId);
    }
}
