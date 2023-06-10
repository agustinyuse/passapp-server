using Domain.Shared;

namespace Domain.Entities;

public class ProfessionalOrganism : BaseEntity
{
    public int ProfessionalId { get; private set; }
    public int OrganismId { get; set; }
}
