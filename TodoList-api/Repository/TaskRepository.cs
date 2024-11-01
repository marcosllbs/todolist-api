using Microsoft.EntityFrameworkCore;
public class TaskRepository : ITaskRepository
{
    protected readonly ITaskContext _context;
    public TaskRepository(ITaskContext context)
    {
        _context = context;
    }

    public IEnumerable<Task> GetTasks()
    {
        return _context.Tasks.Where(task => task.Deleted_AT == null);
    }


    public Task AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return task;
    }

    public Task UpDateTask(Task task, int taskId)
    {
        var myTask = _context.Tasks.Find(taskId);
        if (myTask != null)
        {
            if (task.Description != null && myTask.Description != task.Description)
            {
                myTask.Description = task.Description;
            }

            if (myTask.Done != task.Done)
            {
                myTask.Done = task.Done;
            }

            myTask.Updated_AT = DateTime.Now;
            _context.SaveChanges();

        }
        return myTask!;
    }

    public void DeleteTask(int taskId)
    {
        var myTask = _context.Tasks.Find(taskId);
        if (myTask != null)
        {
            myTask.Deleted_AT = DateTime.Now;
            _context.SaveChanges();
        }
    }

}