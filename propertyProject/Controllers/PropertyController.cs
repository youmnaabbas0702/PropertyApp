namespace propertyProject.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyServices _propertyServices;
        private readonly IUserServices _userServices;


        public PropertyController(IPropertyServices propertyServices, IUserServices userServices)
        {
            _propertyServices = propertyServices;
            _userServices = userServices;
        }
        public async Task<IActionResult> Index(int id, string genderFilter, string sortOrder)
        {
            ViewData["UserId"] = 0;

            var properties = await _propertyServices.GetPropertiesAsync(id, genderFilter, sortOrder);

            // Pass the properties to the view
            return View(properties);
        }
         public async Task<IActionResult> UserProperties(int id, string genderFilter, string sortOrder)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            IEnumerable<Property> properties = new List<Property>();
            if (userId != 0)
            {
                User? user = await _userServices.GetUserByIdAsync(userId);

                properties = await _propertyServices.GetPropertisForUserAsync(id, user.Gender, sortOrder);
            }
            ViewData["UserId"] = userId; // Store the session value in ViewData

            // Pass the properties to the view
            return View("Index",properties);
        }


        public async Task<IActionResult> Details(int id)
        {
            Property? property = await _propertyServices.GetPropertyByIdAsync(id);

            return View(property);
        }
    }
}
