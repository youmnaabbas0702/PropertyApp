namespace propertyProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginFormViewModel model)
        {
            var adminEmails = _userServices.GetAdminEmails();
            if (ModelState.IsValid)
            {

                if (adminEmails.Contains(model.Email))
                {
                    Admin? admin = await _userServices.GetAdminAsync(model);

                    if (admin == null) { ViewBag.Error = "invalid login"; return View("Login"); }

                    HttpContext.Session.SetInt32("AdminId", admin.Id);

                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    User? User = await _userServices.GetUserAsync(model);

                    if (User == null) { ViewBag.Error = "invalid login"; return View("Login"); }

                    HttpContext.Session.SetString("UserName", User.Name);
                    HttpContext.Session.SetInt32("UserId", User.Id);

                    return RedirectToAction("UserProperties", "Property", new { id = User.CityId });
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            var model = _userServices.GetRegisterFormViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userServices.AddUserAsync(model);

                return RedirectToAction("Login");
            }

            model.Genders = _userServices.GetGendersList();
            model.Cities = _userServices.GetCities();

            return View(model);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
