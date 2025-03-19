using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Domain.Models.Base;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    internal abstract void ValidateDomain();
}
