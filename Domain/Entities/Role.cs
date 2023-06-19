using Expensely.Domain.Shared;

namespace Domain.Entities;

public sealed class Role : Enumeration<Role>
{
    public static readonly Role Pases = new(1, "Pases");

    public Role(int id, string name) : base(id, name) { }

    public ICollection<RolePermission> Permissions { get; set; }
}
