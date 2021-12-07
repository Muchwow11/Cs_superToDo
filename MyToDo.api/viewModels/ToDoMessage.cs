using SuperTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.api.viewModels
{
    public class ToDoMessage
    {
        public IEnumerable<ToDo> Todos {get; set;}
        public string Message { get; set; }
    }
}
