using Domain.Shared;

namespace Domain.Entities;

public class Permission : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}
