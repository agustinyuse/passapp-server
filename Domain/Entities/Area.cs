using Domain.Shared;

namespace Domain.Entities;

public class Area : BaseEntity
{
    public string Description { get; private set; }
    public int OrganismId { get; set; }
}
