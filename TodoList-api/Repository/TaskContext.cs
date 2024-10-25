using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext, ITaskContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
    public DbSet<Task> Tasks { get; set; } = null!;
    public TaskContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connetionString = "Server=127.0.0.1;Database=to_do_list_db;User=SA;Password=ToDoList1234@;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connetionString);
        }
    }
}