using Domain.Shared;

namespace Domain.Entities;

public class UserRole: BaseEntity
{
    public UserRole(int roleId)
    {
        RoleId = roleId;
    }

    public int UserId { get; private set; }
    public User User { get; private set; }
    public int RoleId { get; private set; }
    public Role Role { get; private set; }

    public static UserRole Create(int roleId)
    {
        return new UserRole(roleId);
    }
}
