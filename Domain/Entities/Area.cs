using Domain.Shared;

namespace Domain.Entities;

public sealed class Area : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; private set; }
    public int OrganizationId { get; set; }
}
