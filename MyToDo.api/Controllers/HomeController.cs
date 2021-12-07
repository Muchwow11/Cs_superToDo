using Microsoft.AspNetCore.Mvc;
using MyToDo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDo.api.viewModels;

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

        public IActionResult SingleToDo(int id)
        {
            var movie = _services.GetById(id);
            return View(movie);
        }
    }
}

