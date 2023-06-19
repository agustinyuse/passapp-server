using Domain.Shared;

namespace Domain.Entities;

public sealed class User : BaseEntity
{
    private readonly List<UserRole> _roles = new();

    public string Email { get; set; }
    public string Password { get; set; }
    public IReadOnlyCollection<UserRole> Roles => _roles;

    public User(string email, 
        string password)
    {
        Email = email;
        Password = password;
        AddRole(Role.Pases.Id);
    }   

    public static User Create(string email, 
        string password)
    {
        return new User(email, password);      
    }

    public void AddRole(int roleId)
    {
        _roles.Add(UserRole.Create(roleId));
    }
}
