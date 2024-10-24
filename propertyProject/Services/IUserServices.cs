namespace propertyProject.Services
{
    public interface IUserServices
    {
        Task<Admin?> GetAdminAsync(LoginFormViewModel model);
        Task<User?> GetUserAsync(LoginFormViewModel model);
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(RegisterFormViewModel model);
        Task EditUserAsync(User user, EditFormViewModel model);
        Task DeleteUserAsync(User user);
        List<string> GetAdminEmails();
        IEnumerable<SelectListItem> GetCities();
        EditFormViewModel GetEditFormViewModel(User user);
        RegisterFormViewModel GetRegisterFormViewModel();
        IEnumerable<SelectListItem> GetGendersList();
    }
}
