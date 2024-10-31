using System.ComponentModel.DataAnnotations;

public class Task
{

    [Key]
    public int TaskId { get; set; }
    public string? Description { get; set; }
    public bool Done { get; set; }
    public DateTime Created_AT { get; set; } = DateTime.Now;
    public DateTime? Updated_AT { get; set; } = null;
    public DateTime? Deleted_AT { get; set; } = null;

}