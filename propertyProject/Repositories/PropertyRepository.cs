
using propertyProject.Models;

namespace propertyProject.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(int cityId, string genderFilter, string sortOrder)
        {
            var propertiesQuery = _context.Properties
            .Where(p => p.CityId == cityId)
            .Include(p => p.City)
            .Include(p => p.Images)
            .Include(p => p.PropertyServices)
                .ThenInclude(ps => ps.Service)
            .AsQueryable();

            if (!string.IsNullOrEmpty(genderFilter))
            {
                if (Enum.TryParse<Gender>(genderFilter, out var genderEnum))
                {
                    propertiesQuery = propertiesQuery.Where(p => p.Gender == genderEnum);
                }
            }

            propertiesQuery = sortOrder switch
            {
                "asc" => propertiesQuery.OrderBy(p => p.Price),
                "desc" => propertiesQuery.OrderByDescending(p => p.Price),
                _ => propertiesQuery.OrderBy(p => p.Id),
            };

            return await propertiesQuery.ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertisForUserAsync(int userCity, Gender userGender, string sortOrder)
        {
            var propertiesQuery = _context.Properties
            .Where(p => p.CityId == userCity && p.Gender == userGender)
            .Include(p => p.City)
            .Include(p => p.Images)
            .Include(p => p.PropertyServices)
                .ThenInclude(ps => ps.Service)
            .AsQueryable();

            propertiesQuery = sortOrder switch
            {
                "asc" => propertiesQuery.OrderBy(p => p.Price),
                "desc" => propertiesQuery.OrderByDescending(p => p.Price),
                _ => propertiesQuery.OrderBy(p => p.Id),
            };

            return await propertiesQuery.ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.Images)
                .Include(p => p.PropertyServices)
                .ThenInclude(s => s.Service)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddPropertyAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePropertyAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePropertyAsync(int id)
        {
            Property? property = await GetPropertyByIdAsync(id);
            
            _context.Properties.Remove(property!);

            await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAvailableServicesList()
        {
            var AvailableServices = _context.Services.Select(s => new SelectListItem
            { Value = s.Id.ToString(), Text = s.Name })
                .OrderBy(s => s.Text)
                .ToList();
            return AvailableServices;
        }

        public Property? GetLastPropertyInCity(int cityId)
        {
            Property? lastProperty = _context.Properties
                    .Where(u => u.CityId == cityId)
                    .OrderByDescending(u => u.Id)
                    .FirstOrDefault();
            return lastProperty;
        }

        public void SavePropertyImages(Image image)
        {
            _context.Images.Add(image);
             _context.SaveChanges();
        }
    }
}
