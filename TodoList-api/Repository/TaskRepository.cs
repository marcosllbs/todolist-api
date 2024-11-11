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
        return _context.Tasks.Where(task => task.Deleted_AT == null)
        .Include(task => task.SubTasks);
    }


    public Task AddTask(Task task)
    {
        _context.Tasks.Add(task);
        task.Done = false;
        _context.SaveChanges();
        return task;
    }

    public SubTask AddSubTask(SubTask subTask, int taskId)
    {
        var task = _context.Tasks.Include(task => task.SubTasks).FirstOrDefault(task => task.TaskId == taskId);

        if (task != null)
        {

            subTask.TaskId = taskId;
            subTask.Created_AT = DateTime.Now;

            task.SubTasks?.Add(subTask);


            _context.SaveChanges();
        }

        return subTask;
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

            if (task.Done != null)
            {
                myTask.Done = task.Done;
            }

            myTask.Updated_AT = DateTime.Now;
            _context.SaveChanges();

        }
        return myTask!;
    }

    public SubTask? UpDateSubTask(SubTask updatedSubTask, int subTaskId)
    {

        var subTask = _context.SubTasks.FirstOrDefault(st => st.SubTaskID == subTaskId);

        if (subTask != null)
        {

            if (updatedSubTask.Description != null && subTask.Description != updatedSubTask.Description)
            {
                subTask.Description = updatedSubTask.Description;
            }

            if (updatedSubTask.Done != null)
            {
                subTask.Done = updatedSubTask.Done;
            }


            subTask.Updated_AT = DateTime.Now;


            _context.SaveChanges();
        }

        return subTask;
    }

    public void DeleteTask(int taskId)
    {
        var myTask = _context.Tasks.Find(taskId);
        if (myTask != null)
        {
            myTask.Deleted_AT = DateTime.Now;
            if (myTask.SubTasks != null)
            {
                foreach (var subTask in myTask.SubTasks)
                {
                    subTask.Deleted_AT = DateTime.Now;
                }
                _context.SaveChanges();
            }
        }
    }
    public void DeleteSubTask(int subTaskId)
    {

        var subTask = _context.SubTasks.FirstOrDefault(st => st.SubTaskID == subTaskId);

        if (subTask != null)
        {

            subTask.Deleted_AT = DateTime.Now;


            _context.SaveChanges();
        }

    }
}