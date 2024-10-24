namespace propertyProject.Services
{
    public class PropertyServices : IPropertyServices
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyServices(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(int cityId, string genderFilter, string sortOrder)
        {
            return await _propertyRepository.GetPropertiesAsync(cityId, genderFilter, sortOrder);
        }

        public async Task<IEnumerable<Property>> GetPropertisForUserAsync(int userCity, Gender userGender, string sortOrder)
        {
            return await _propertyRepository.GetPropertisForUserAsync(userCity, userGender,sortOrder);
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetPropertyByIdAsync(id);
        }
        public async Task AddPropertyAsync(AddPropertyFormViewModel model, int adminId)
        {
            //property cover image
            string coverImagePath = await SaveCoverImage(model);

            //object of property
            var newProperty = new Property()
            {
                Address = model.Address,
                Price = model.Price,
                RoomsAvailable = model.RoomsAvailable,
                ContactNumber = model.ContactNumber,
                CityId = adminId,
                Gender = model.Gender,
                Description = model.Description,
                CoverImage = coverImagePath,
                PropertyServices = model.SelectedServiceIds.Select(id => new PropertyService
                {
                    ServiceId = id
                }).ToList()
            };

            //setting property id
            var lastProperty = _propertyRepository.GetLastPropertyInCity(newProperty.CityId);
            
            if (lastProperty != null)
            {
                int lastId = lastProperty.Id % 1000;  // Remove city part
                newProperty.Id = (newProperty.CityId * 1000) + (lastId + 1);
            }
            else
            {
                newProperty.Id = (newProperty.CityId * 1000) + 1;
            }

            await _propertyRepository.AddPropertyAsync(newProperty);

            //Save additional images
            await SavePropertyImages(model, newProperty);
        }

        public async Task UpdatePropertyAsync(EditPropertyFormViewModel model)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(model.Id);
            if (property != null)
            {
                property.Address = model.Address;
                property.Price = model.Price;
                property.RoomsAvailable = model.RoomsAvailable;
                property.ContactNumber = model.ContactNumber;
                property.Gender = model.Gender;
                property.Description = model.Description;

                property.PropertyServices.Clear();
                property.PropertyServices = model.SelectedServiceIds.Select(id => new PropertyService { ServiceId = id }).ToList();

                await _propertyRepository.UpdatePropertyAsync(property);
            }
        }

        public async Task DeletePropertyAsync(int id)
        {

            await _propertyRepository.DeletePropertyAsync(id);
        }

        public AddPropertyFormViewModel GetAddFormViewModel()
        {
            AddPropertyFormViewModel model = new()
            {
                Genders = GetGendersList(),
                AvailableServices = _propertyRepository.GetAvailableServicesList()
            };

            return model;
        }

        public EditPropertyFormViewModel GetEditFormViewModel(int id, Property property, List<int> servicesIds)
        {
            EditPropertyFormViewModel model = new EditPropertyFormViewModel()
            {
                Id = id,
                Address = property.Address,
                Price = property.Price,
                RoomsAvailable = property.RoomsAvailable,
                ContactNumber = property.ContactNumber,
                Description = property.Description,
                SelectedServiceIds = servicesIds,
                Gender = property.Gender,
                Genders = GetGendersList(),
                AvailableServices = GetAvailableServicesList()
            };
            return model;
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

        public IEnumerable<SelectListItem> GetAvailableServicesList()
        {
            return _propertyRepository.GetAvailableServicesList();
        }

        private async Task<string> SaveCoverImage(AddPropertyFormViewModel model)
        {
            string coverImagePath = null;

            if (model.CoverImage != null)
            {
                string coverFileName = Path.GetFileNameWithoutExtension(model.CoverImage.FileName);
                string coverExtension = Path.GetExtension(model.CoverImage.FileName);
                string coverNewFileName = $"{coverFileName}_{Guid.NewGuid()}{coverExtension}";
                string coverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/properties", coverNewFileName);

                using (var stream = new FileStream(coverPath, FileMode.Create))
                {
                    await model.CoverImage.CopyToAsync(stream);
                }

                coverImagePath = $"images/properties/{coverNewFileName}";
            }
            return coverImagePath;
        }

        private async Task SavePropertyImages(AddPropertyFormViewModel model,Property newProperty)
        {
            if (model.Images != null && model.Images.Count > 0)
            {
                foreach (var imageFile in model.Images)
                {
                    string imageFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    string imageExtension = Path.GetExtension(imageFile.FileName);
                    string newImageFileName = $"{imageFileName}_{Guid.NewGuid()}{imageExtension}";
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/properties", newImageFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    var image = new Image
                    {
                        ImagePath = $"images/properties/{newImageFileName}",
                        PropertyId = newProperty.Id
                    };

                    _propertyRepository.SavePropertyImages(image);
                }

            }
        }
    }
}
