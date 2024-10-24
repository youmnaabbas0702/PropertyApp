namespace propertyProject.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Admin?> GetAdminAsync(LoginFormViewModel model)
        {
            return await _userRepository.GetAdminAsync(model);
        }

        public async Task<User?> GetUserAsync(LoginFormViewModel model)
        {
            return await _userRepository.GetUserAsync(model);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(RegisterFormViewModel model)
        {
            var newUser = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                CityId = model.CityId,
                Gender = model.Gender,
            };

            var lastUser = await _userRepository.GetLastUserInCity(newUser);

            if (lastUser != null)
            {
                // Extract the numeric part of the last user id
                // Assuming user.Id is a numeric value, e.g., 1001, 1002, etc.
                int lastId = lastUser.Id % 1000;  // Remove city part
                newUser.Id = (newUser.CityId * 1000) + (lastId + 1);
            }
            else
            {
                // No users in this city yet, start with cityId * 1000 + 1
                newUser.Id = (newUser.CityId * 1000) + 1;
            }

            await _userRepository.AddUserAsync(newUser);
        }
        
        public async Task EditUserAsync(User user, EditFormViewModel model)
        {
            await _userRepository.EditUserAsync(user, model);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userRepository.DeleteUserAsync(user);
        }

        public List<string> GetAdminEmails()
        {
            return _userRepository.GetAdminEmails();
        }

        public IEnumerable<SelectListItem> GetCities()
        {
            return _userRepository.GetCities();
        }

        public EditFormViewModel GetEditFormViewModel(User user)
        {
            EditFormViewModel model = new EditFormViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Cities = GetCities(),
                CityId = user.CityId,

            };
            return model;
        }

        public RegisterFormViewModel GetRegisterFormViewModel()
        {
            return new RegisterFormViewModel()
            {
                Genders = GetGendersList(),
                Cities = GetCities()
            };
        }

        public IEnumerable<SelectListItem> GetGendersList()
        {
            var Genders = Enum.GetValues(typeof(Gender))
                   .Cast<Gender>()
                   .Select(g => new SelectListItem
                   {
                       Value = g.ToString(),
                       Text = g.ToString()
                   });
            return Genders;
        }
    }
}
