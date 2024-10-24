namespace propertyProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        { 
            _context = context;
        }
        public async Task<Admin?> GetAdminAsync(LoginFormViewModel model)
        {
            return await _context.Admins.FirstOrDefaultAsync(e => e.Email == model.Email && e.Password == model.Password);
        }
       
        public async Task<User?> GetUserAsync(LoginFormViewModel model)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == model.Email && e.Password == model.Password);
        }
        
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.City)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetLastUserInCity(User newUser)
        {
            return await _context.Users
                    .OrderByDescending(u => u.Id)
                    .FirstOrDefaultAsync(u => u.CityId == newUser.CityId);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditUserAsync(User user,EditFormViewModel model)
        {
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.NewPassword;
            user.CityId = model.CityId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public List<string> GetAdminEmails()
        {
            return _context.Admins.Select(x => x.Email).ToList();
        }

        public IEnumerable<SelectListItem> GetCities()
        {
            return _context.Cities.Select(c => new SelectListItem
            { Value = c.CityId.ToString(), Text = c.CityName }).ToList();
        }
    }
}
