using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyToDo.api.viewModels;
using SuperTodo;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.api.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserManager<User> _userService;
        private readonly SignInManager<User> _signInService;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = userManager;
            _signInService = signInManager;
        }

        public IActionResult Index() => RedirectToAction("Registration");

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid && (model.Password == model.ConfirmPassword))
            {
                var newUser = new User() { Email = model.Email, FullName = model.Name };

                var result = await _userService.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    await _signInService.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("index", "Admin");
                }

                TempData["Errors"] = result.Errors.First().Description;


            }

            return View(model);
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var myUser = await _userService.FindByEmailAsync(model.Email);

                if (myUser != null)
                {
                    var result = await _signInService.PasswordSignInAsync(myUser, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
            }

            return View(model);
        }
    }
}
