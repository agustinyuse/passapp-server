using Domain.Enums;
using Expensely.Domain.Shared;

namespace Domain.Entities;

public sealed class Permission : Enumeration<Permission>
{
    public static readonly Permission AccessPase = new((int)PermissionEnum.AccessPase, PermissionEnum.AccessPase.ToString());
    public static readonly Permission ReadPase = new((int)PermissionEnum.ReadPase, PermissionEnum.ReadPase.ToString());
    public static readonly Permission AddPase = new((int)PermissionEnum.AddPase, PermissionEnum.AddPase.ToString());
    public static readonly Permission UpdatePase = new((int)PermissionEnum.UpdatePase, PermissionEnum.UpdatePase.ToString());
    public static readonly Permission DeletePase = new((int)PermissionEnum.DeletePase, PermissionEnum.DeletePase.ToString());

    public Permission(int id, string name) : base(id, name) { }
}
