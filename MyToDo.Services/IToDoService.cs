using System;
using System.Collections.Generic;
using System.Text;
using SuperTodo;
namespace MyToDo.Services
{
    public interface IToDoService
    {
        ToDo SaveTodo(ToDo item);
        ToDo UpdateTodo(ToDo item);
        IEnumerable<ToDo> GetAll();
        ToDo GetById(int id);
        IEnumerable<ToDo> GetActive();
        ToDo Put(int id, bool status);
    }
}
