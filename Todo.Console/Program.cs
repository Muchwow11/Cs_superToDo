using MyToDo.DataAccess;
using MyToDo.Services;
using SuperTodo;
using System;

namespace myTodo.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            
            do
            {
                Console.WriteLine("Irasykite savo todo:");
                var answer = Console.ReadLine();

                if (answer == "x")
                {
                    loop = false;
                }
                else
                {
                    var tempToDo = new ToDo() { Title = answer };

                    IToDoService todoService = new ToDoService();
                    ToDo savedTodo =  todoService.SaveTodo(tempToDo);
                    Console.WriteLine(savedTodo.CreatedAt);
                }

            } while (loop);
        }
    }
}
