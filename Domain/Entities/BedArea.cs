using Domain.Shared;

namespace Domain.Entities;

public class BedArea : BaseEntity
{
    public int BedId { get; private set; }
    public int AreaId { get; private set; }
    public int OrganizationId { get; set; }
}
