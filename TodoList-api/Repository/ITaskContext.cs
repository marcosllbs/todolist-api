using Microsoft.EntityFrameworkCore;
public interface ITaskContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<SubTask> SubTasks { get; set; }
    public int SaveChanges();
}