using Microsoft.AspNetCore.Mvc;
using MyToDo.api.viewModels;
using MyToDo.Services;
using SuperTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index() => RedirectToAction("Registration");

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid && model.Password == model.ConfirmPassword)
            {
                User user = new User();
                user.Name = model.Name;
                user.Password = model.Password;
                user.Email = model.Email;

                var myUser = _service.AddUser(user);

                return View("~/Views/Home/Index.cshtml");

            }

            return View(model);
        }
    }
}
