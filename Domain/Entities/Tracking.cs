using Domain.Shared;

namespace Domain.Entities;

public class Tracking : BaseEntity
{
    public int InternmentId { get; private set; }
    public int ProfessionalId { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public int OrganizationId { get; set; }
}
