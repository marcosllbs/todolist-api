public class TaskRepository : ITaskRepository
{
    protected readonly ITaskContext _context;
    public TaskRepository(ITaskContext context)
    {
        _context = context;
    }

    public IEnumerable<Task> GetTasks()
    {
        throw new NotImplementedException();
    }


    public Task AddTask(Task task)
    {
        throw new NotSupportedException();
    }

    public Task UpDateTask(Task task)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTask(Task task)
    {
        throw new NotImplementedException();
    }
}