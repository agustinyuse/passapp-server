using Domain.Shared;

namespace Domain.Entities;

public sealed class ProfessionalOrganization : BaseEntity
{
    public int ProfessionalId { get; private set; }
    public int OrganizationId { get; set; }
}
