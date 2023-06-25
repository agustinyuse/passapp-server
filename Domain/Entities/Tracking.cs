using Domain.Shared;

namespace Domain.Entities;

public sealed class Tracking : BaseEntity
{
    private readonly List<TrackingFile> _trackingFiles = new();

    private Tracking(int internmentId, 
        int professionalId, 
        string description)
    {
        InternmentId = internmentId;
        ProfessionalId = professionalId;
        Description = description;
    }

    public int InternmentId { get; private set; }
    public int ProfessionalId { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; } = DateTime.UtcNow;

    public static Tracking Create(int intermentId,
        int professionalId,
        string description)
    {
        return new Tracking(intermentId, professionalId, description);
    }

    public void AddFiles(List<TrackingFile> trackingFiles)
    {
        _trackingFiles.AddRange(trackingFiles);
    }
}
