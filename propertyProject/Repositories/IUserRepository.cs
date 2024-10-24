namespace propertyProject.Repositories
{
    public interface IUserRepository
    {
        Task<Admin?> GetAdminAsync(LoginFormViewModel model);
        Task<User?> GetUserAsync(LoginFormViewModel model);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetLastUserInCity(User newUser);
        Task AddUserAsync(User user);
        Task EditUserAsync(User user, EditFormViewModel model);
        Task DeleteUserAsync(User user);
        List<string> GetAdminEmails();
        IEnumerable<SelectListItem> GetCities();
    }
}
