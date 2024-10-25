public interface ITaskRepository
{
    IEnumerable<Task> GetTasks();
    Task AddTask(Task task);
    Task UpDateTask(Task task, int TaskId);
    void DeleteTask(int TaskId);
}