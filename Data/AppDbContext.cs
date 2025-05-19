using TodoApp.Model;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Data
{
    public class TaskDbContext: DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskUser>()
                .HasMany(user => user.UserTasks)
                .WithOne(task => task.TaskUser)
                .HasForeignKey(task => task.TaskRequesterId).IsRequired();
        }
        
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<TaskUser> TaskUsers { get; set; }
    }
}