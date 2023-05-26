using Domain.Shared;

namespace Domain.Entities;

public sealed class User: BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<UserRole> Roles { get; set; }
}
