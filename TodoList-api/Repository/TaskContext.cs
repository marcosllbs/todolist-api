using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext, ITaskContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
    public DbSet<Task> Tasks { get; set; } = null!;
    public DbSet<SubTask> SubTasks { get; set; } = null!;
    public TaskContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connetionString = "Server=127.0.0.1;Database=to_do_list_db;User=to_do_user;Password=ToDoList1234@";
            optionsBuilder.UseMySql(connetionString, new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}