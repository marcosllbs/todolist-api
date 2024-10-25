public interface ITaskRepository
{
    IEnumerable<Task> GetTasks();
    Task AddTask(Task task);
    Task UpDateTask(Task task);
    Task DeleteTask(Task task);
}