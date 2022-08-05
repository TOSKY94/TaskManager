using System;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Model;
using TaskMangerAPI.Model;

namespace TaskManagerAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
            public DbSet<Todo> Todos { get; set; }
            public DbSet<User> User { get; set; }

    }
}

