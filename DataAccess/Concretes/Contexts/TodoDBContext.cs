using DataAccess.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.Contexts
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
        {
            
        }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder.ApplyConfiguration(new TodoMap()));
        }

    }
}
