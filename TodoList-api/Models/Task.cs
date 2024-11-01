using System.ComponentModel.DataAnnotations;

public class Task
{

    [Key]
    public int TaskId { get; set; }

    [Required]
    [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres.")]
    [MaxLength(100, ErrorMessage = "A descrição deve ter no maximo 100 caracteres.")]
    public string? Description { get; set; }

    public bool Done { get; set; }
    public DateTime Created_AT { get; set; } = DateTime.Now;
    public DateTime? Updated_AT { get; set; } = null;
    public DateTime? Deleted_AT { get; set; } = null;

}