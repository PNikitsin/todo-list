using Microsoft.EntityFrameworkCore;
using Training.Todo.Models;

namespace Training.Todo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TodoModel> Todoes { get; set; }
    }
}  