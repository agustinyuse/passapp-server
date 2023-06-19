using Domain.Shared;

namespace Domain.Entities;

public class Area : BaseEntity
{
    public string Code { get; set; }
    public string Description { get; private set; }
    public int OrganizationId { get; set; }
}
