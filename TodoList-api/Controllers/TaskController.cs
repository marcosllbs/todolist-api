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
    public IActionResult GetTasks()
    {
        return Ok(_repository.GetTasks());
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] Task task)
    {
        return Created("", _repository.AddTask(task));
    }

    [HttpPut("{taskId}")]
    public IActionResult UpdateTask([FromBody] Task task, int taskId)
    {
        return Ok(_repository.UpDateTask(task, taskId));
    }

    [HttpDelete("{taskId}")]
    public IActionResult DeleteTask(int taskId)
    {
        _repository.DeleteTask(taskId);
        return NoContent();
    }

    [HttpPut("{taskId}/finishtask")]
    public IActionResult FinishTask(int taskId)
    {
        return NoContent();
    }
}