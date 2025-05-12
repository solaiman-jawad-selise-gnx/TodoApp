using TodoApp.Model;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Data
{
    public class TaskDbContext: DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}