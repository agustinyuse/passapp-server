using Domain.Shared;

namespace Domain.Entities;

public class Bed: BaseEntity
{
    public string BedCode { get; private set; }
    public string Description { get; private set; }
    public int OrganismId { get; set; }
}
