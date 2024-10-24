namespace propertyProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPropertyServices _propertyServices;

        public AdminController(IPropertyServices propertyServices)
        {
            _propertyServices = propertyServices;
        }
        public async Task<IActionResult> Index(string genderFilter, string sortOrder)
        {
            int currentAdmin = (int)HttpContext.Session.GetInt32("AdminId")!;
            
            var properties = await _propertyServices.GetPropertiesAsync(currentAdmin, genderFilter, sortOrder);
            return View(properties);
        }

        public IActionResult Add()
        {
            AddPropertyFormViewModel model = _propertyServices.GetAddFormViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddPropertyFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                int currentAdmin = (int)HttpContext.Session.GetInt32("AdminId")!;

                await _propertyServices.AddPropertyAsync(model, currentAdmin);

                return RedirectToAction("Index");
            }

            //if not valid
            model.Genders = _propertyServices.GetGendersList();
            model.AvailableServices = _propertyServices.GetAvailableServicesList();
            
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Property? property = await _propertyServices.GetPropertyByIdAsync(id);

            List<int> servicesIds = new List<int>();
            foreach (var service in property.PropertyServices)
            {
                servicesIds.Add(service.ServiceId);
            }

            var model = _propertyServices.GetEditFormViewModel(id, property,servicesIds);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPropertyFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _propertyServices.UpdatePropertyAsync(model);

                return RedirectToAction("Index");
            }

            //if not valid
            model.Genders = _propertyServices.GetGendersList();
            model.AvailableServices = _propertyServices.GetAvailableServicesList();

            return View(model);
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await _propertyServices.DeletePropertyAsync(id);

            return RedirectToAction("Index");
        }
    }
}
