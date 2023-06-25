using Domain.Errors;
using Domain.Shared;

namespace Domain.Entities;

public sealed class Pase : BaseEntity
{
    private readonly List<Internment> _internations = new();
    private readonly List<PaseUserPasePermission> _userPermissions = new();
    private Pase(string name, 
        int organizationId,
        int? areaId)
    {
        Name = name;
        OrganizationId = organizationId;
        AreaId = areaId;
    }

    public string Name { get; private set; }
    public int OrganizationId { get; private set; }
    public Organization Organization { get; private set; }
    public int? AreaId { get; set; }

    public IReadOnlyCollection<Internment> Internments => _internations;
    public IReadOnlyCollection<PaseUserPasePermission> UserPermissions => _userPermissions;

    public static Result<Pase> Create(int organizationId,
        int? areaId,
        string name)
    {
        var pase = new Pase(name,
            organizationId,
            areaId);

        if (organizationId == 0)
        {
            return Result.Failure<Pase>(DomainErrors.Pase.OrganizationRequired);
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Pase>(DomainErrors.Pase.DescriptionRequired);
        }

        return pase;
    }

    public void Add(int userId, 
        Domain.Enums.PasePermissionEnum pasePermissionId)
    {
        PaseUserPasePermission paseUserPermission = PaseUserPasePermission.Create(this.Id, 
            userId, 
            pasePermissionId);

        _userPermissions.Add(paseUserPermission);
    }

    public List<PaseUserPasePermission> GetUsers()
    {
        return _userPermissions;
    }
}
