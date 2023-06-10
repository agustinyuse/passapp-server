using Domain.Shared;

namespace Domain.Entities;

public class Internment : BaseEntity
{
    public int PatientId { get; private set; }
    public DateTime AdmissionDate { get; private set; }
    public int BedAreaId { get; private set; }
    public DateTime DischargeDate { get; private set; }
}
