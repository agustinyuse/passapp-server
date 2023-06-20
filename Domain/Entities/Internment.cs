using Domain.Shared;

namespace Domain.Entities;

public sealed class Internment : BaseEntity
{
    public int PatientId { get; private set; }
    public DateTime AdmissionDate { get; private set; }
    public string Bed { get; private set; }
    public int? BedId { get; private set; }
    public DateTime DischargeDate { get; private set; }
}
