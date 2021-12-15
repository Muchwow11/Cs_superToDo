using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyToDo.api.viewModels;
using MyToDo.Services;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {

        private readonly IToDoService _services;

        public HomeController(IToDoService todoService)
        {
            _services = todoService;
        }


        //controleri medotai vadinami action
        public IActionResult Index()
        {
            var todos = _services.GetAll();
            string message = "Siandien butinai pirk pieno";
            var todoWithMessage = new ToDoMessage();

            todoWithMessage.Message = message;
            todoWithMessage.Todos = todos;

            ViewBag.Title = "Hello";
            TempData["Svarbu"] = "Kas svarbu";

            return View(todoWithMessage);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ContactUs(string id)
        {
            ViewBag.test = User.Identity.Name;

            string foo = "ka yra";
            string bar = "nieka";

            KlausimoViewModel model = new KlausimoViewModel()
            {
                Klausimas = foo,
                Atsakymas = bar
            };

            return View(model);
        }
        public IActionResult ToDo(int id)
        {
            var myTodo = _services.GetById(id);
            return View(myTodo);
        }
    }
}

