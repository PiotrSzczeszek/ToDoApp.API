using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data.Entities;

namespace ToDoApp.Data
{
    public class ToDoAppContext : DbContext
    {

        public DbSet<Task> Tasks { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> Users { get; set; }

        public ToDoAppContext(DbContextOptions<ToDoAppContext> options)
            :base(options)
        {
            
            
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration<>).Assembly);
        }
    }
}
