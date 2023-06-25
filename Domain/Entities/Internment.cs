using Domain.Shared;
using System.Collections.ObjectModel;

namespace Domain.Entities;

public sealed class Internment : BaseEntity
{
    private readonly List<Tracking> _tracking = new();
    private Internment(int patientId, 
        string bed,
        int? bedId)
    {
        PatientId = patientId;
        Bed = bed;
        BedId = bedId;
    }

    public int PatientId { get; private set; }
    public DateTime AdmissionDate { get; private set; } = DateTime.UtcNow;
    public string Bed { get; private set; }
    public int? BedId { get; private set; }
    public DateTime DischargeDate { get; private set; }
    public IReadOnlyCollection<Tracking> Trackings => _tracking;

    public static Internment Create(int patientId,
        string bed,
        int? bedId)
    {
        return new Internment(patientId, bed, bedId);
    }

    public void AddTracking(int intermentId,
        int professionalId,
        string description)
    {
        var tracking = Tracking.Create(intermentId, professionalId, description);

        _tracking.Add(tracking);
    }

    public void Discharge() => DischargeDate = DateTime.UtcNow;
}
