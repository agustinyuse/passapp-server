using Domain.Shared;

namespace Domain.Entities;

public class ProfessionalOrganization : BaseEntity
{
    public int ProfessionalId { get; private set; }
    public int OrganizationId { get; set; }
}
