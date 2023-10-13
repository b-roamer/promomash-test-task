namespace Domain.Entities;

public abstract class EntityBase
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}