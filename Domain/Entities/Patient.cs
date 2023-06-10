using Domain.Enums;
using Domain.Shared;

namespace Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender GenderId { get; private set; }
    public DocumentType DocumentTypeId { get; private set; }
    public string DocumentNumber { get; private set; }
    public int HealthInsurancePlanId { get; private set; }
    public int OrganismId { get; set; }
}
