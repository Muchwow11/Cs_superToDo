using MyToDo.DataAccess;
using SuperTodo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToDo.Services
{
    public class ToDoService : IToDoService
    {

        private readonly ApplicationDbContext _db;

        public ToDoService(ApplicationDbContext services)
        {
            _db = services;
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _db.ToDos.ToList();
        }
        public ToDo Put(int id, bool status)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var entity = dbContext.ToDos.FirstOrDefault(e => e.ToDoId == id);

                entity.Status = status;

                dbContext.SaveChanges();

                return entity;
            }

           
        }
        public IEnumerable<ToDo> GetActive()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.ToDos.Where(e => e.Status == true).ToList();
            }
        }


        public ToDo SaveTodo(ToDo item)
        {
            using (var db = new ApplicationDbContext())
            {
                item.CreatedAt = DateTime.Now;
                db.Add(item);
                db.SaveChanges();
            }

            return item;
        }

        public ToDo UpdateTodo(ToDo item)
        {
            using (var db = new ApplicationDbContext())
            {
                var todoFromDB = db.ToDos.First(t => t.Title == item.Title);
                todoFromDB.Description = item.Description;

                db.Add(todoFromDB);
                db.SaveChanges();
            }

            return item;
        }

        public ToDo GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.ToDos.FirstOrDefault(t => t.ToDoId == id);
            }
        }
    }
}
