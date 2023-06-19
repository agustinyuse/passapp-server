using Domain.Enums;
using Domain.Shared;

namespace Domain.Entities;

public sealed class PaseUserPasePermission : BaseEntity
{
    public PaseUserPasePermission(int paseId,
        int userId,
        Domain.Enums.PasePermissionEnum pasePermissionId)
    {
        PaseId = paseId;
        UserId = userId;
        PasePermissionId = pasePermissionId;
    }

    public int PaseId { get; private set; }
    public Pase Pase { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
    public Domain.Enums.PasePermissionEnum PasePermissionId { get; private set; }
}
