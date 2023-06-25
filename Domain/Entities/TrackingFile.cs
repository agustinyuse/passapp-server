using Domain.Shared;

namespace Domain.Entities;

public sealed class TrackingFile : BaseEntity
{
    private TrackingFile(int trackingId, 
        string fileName, 
        string path, 
        string fileType,
        int fileSize)
    {
        TrackingId = trackingId;
        FileName = fileName;
        Path = path;
        FileType = fileType;
        FileSize = fileSize;
    }


    public int TrackingId { get; private set; }
    public string FileName { get; private set; }
    public string Path { get; private set; }
    public string FileType { get; private set; }
    public int FileSize { get; private set; }
}
