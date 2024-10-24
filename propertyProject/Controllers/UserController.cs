namespace propertyProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<IActionResult> Index()
        {
            int currentUser = (int)HttpContext.Session.GetInt32("UserId")!;

            var user = await _userServices.GetUserByIdAsync(currentUser);

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);

            var model = _userServices.GetEditFormViewModel(user);

            if (user == null) return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFormViewModel model)
        {
            int currentUser = (int)HttpContext.Session.GetInt32("UserId")!;

            User? user = await _userServices.GetUserByIdAsync(currentUser);

            if (user == null) return NotFound();

            if (ModelState.IsValid)
            {
                await _userServices.EditUserAsync(user, model);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            
            await _userServices.DeleteUserAsync(user);

            return RedirectToAction("LogOut", "Account");
        }
    }
}
