using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class SubTask
{
    [Key]
    public int SubTaskID { get; set; }

    [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres.")]
    [MaxLength(100, ErrorMessage = "A descrição deve ter no maximo 100 caracteres.")]
    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? Done { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created_AT { get; set; } = DateTime.UtcNow;
    [Column(TypeName = "datetime")]
    public DateTime? Updated_AT { get; set; } = null;
    [Column(TypeName = "datetime")]
    public DateTime? Deleted_AT { get; set; } = null;

    [ForeignKey("TaskId")]
    public int TaskId { get; set; }
}