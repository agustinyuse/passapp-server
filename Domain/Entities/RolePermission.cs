using Domain.Shared;

namespace Domain.Entities;

public sealed class RolePermission : BaseEntity
{
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
}
