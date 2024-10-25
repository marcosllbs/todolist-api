using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("tasks")]

public class TaskController : ControllerBase
{
    private readonly ITaskRepository _repository;
    public TaskController(ITaskRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<Task> GetTasks()
    {
        return _repository.GetTasks();
    }

    [HttpPost]
    public Task PostTask([FromBody] Task task)
    {
        return task;
    }
}