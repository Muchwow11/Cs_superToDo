using Microsoft.AspNetCore.Mvc;
using MyToDo.api.viewModels;
using MyToDo.DataAccess;
using MyToDo.Services;
using SuperTodo;
using System.Collections.Generic;
using System.Linq;

namespace MyToDo.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService toDoService)
        {
            _service = toDoService;
        }


        [HttpGet]
        public IEnumerable<ToDo> Get([FromQuery] int page = 1, int size = 1)
        {

            return _service.GetAll(page, size);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var result = _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDoViewModelBool model)
        {
            _service.Put(id, model.Status);

            return Ok();
        
        }

        [HttpGet]
        [Route("geta")]
        public IEnumerable<ToDo> Geta()
        {
            return _service.GetActive();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoViewModel model)
        {
            ToDo todo = new ToDo() { Title = model.ToDo, Status = model.Status };
            var result = _service.SaveTodo(todo);
            return Ok(result);
        }

        //[HttpDelete]
        //public IActionResult Delete(ToDoViewModel del)
        //{

        //}
    }
}
