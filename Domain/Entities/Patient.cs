using Domain.Enums;
using Domain.Shared;

namespace Domain.Entities;

public sealed class Patient : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public DateTime BirthDate { get; private set; }
    public GenderEnum GenderId { get; private set; }
    public DocumentTypeEnum DocumentTypeId { get; private set; }
    public string DocumentNumber { get; private set; }
    public int HealthInsurancePlanId { get; private set; }
    public int OrganizationId { get; set; }
}
