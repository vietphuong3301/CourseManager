using System.ComponentModel.DataAnnotations;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
