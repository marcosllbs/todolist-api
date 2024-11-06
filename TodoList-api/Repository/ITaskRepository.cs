public interface ITaskRepository
{
    IEnumerable<Task> GetTasks();
    Task AddTask(Task task);
    Task UpDateTask(Task task, int TaskId);
    SubTask AddSubTask(SubTask subTask, int TaskId);
    SubTask? UpDateSubTask(SubTask subTask, int TaskId);

    void DeleteTask(int TaskId);
    void DeleteSubTask(int SubTaskId);
}