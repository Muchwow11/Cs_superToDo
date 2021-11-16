
using Microsoft.EntityFrameworkCore;
using SuperTodo;
using System;

namespace MyToDo.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public string DbPath { get; private set; }

        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}ToDo.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<ToDo> ToDos { get; set; }

    }
}
