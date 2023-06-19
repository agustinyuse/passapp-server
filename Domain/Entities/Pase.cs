using Domain.Errors;
using Domain.Shared;

namespace Domain.Entities;

public sealed class Pase : BaseEntity
{
    private readonly List<Internment> _internations = new();
    private readonly List<PaseUserPasePermission> _userPermissions = new();
    public Pase(string name, 
        int organizationId)
    {
        Name = name;
        OrganizationId = organizationId;
    }

    public string Name { get; private set; }
    public int OrganizationId { get; private set; }
    public Organization Organization { get; private set; }

    public IReadOnlyCollection<Internment> Internments => _internations;
    public IReadOnlyCollection<PaseUserPasePermission> UserPermissions => _userPermissions;

    public static Result<Pase> Create(int organizationId,
        string name)
    {
        var pase = new Pase(name,
            organizationId);

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
        PaseUserPasePermission paseUserPermission = new PaseUserPasePermission(this.Id, 
            userId, 
            pasePermissionId);

        _userPermissions.Add(paseUserPermission);
    }
}
