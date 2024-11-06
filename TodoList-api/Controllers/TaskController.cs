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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetTasks()
    {
        return Ok(_repository.GetTasks());
    }

    [HttpPost]
    [ProducesResponseType(typeof(Task), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddTask([FromBody] Task task)
    {
        return Created("", _repository.AddTask(task));
    }

    [HttpPost("subtasks/{taskId:int}")]
    [ProducesResponseType(typeof(Task), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddSubTask([FromBody] SubTask subTask, int taskId)
    {
        return Created("", _repository.AddSubTask(subTask, taskId));
    }

    [HttpPut("{taskId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateTask([FromBody] Task task, int taskId)
    {
        return Ok(_repository.UpDateTask(task, taskId));
    }

    [HttpPut("subtasks/{taskId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateSubTask([FromBody] SubTask subTask, int taskId)
    {
        return Ok(_repository.UpDateSubTask(subTask, taskId));
    }

    [HttpDelete("{taskId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteTask(int taskId)
    {
        _repository.DeleteTask(taskId);
        return NoContent();
    }

    [HttpDelete("subtasks/{taskId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteSubTask(int taskId)
    {
        _repository.DeleteTask(taskId);
        return NoContent();
    }

    [HttpPut("{taskId:int}/finishtask")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult FinishTask(int taskId)
    {
        return NoContent();
    }
}