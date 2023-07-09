using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Console_App
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB ;Database=TodolistApp;Trusted_Connection=True;MultipleActiveResultSets=true");

        }
    }



    

}
