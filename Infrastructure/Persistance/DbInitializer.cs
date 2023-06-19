using Application.Abstractions.Data;
using Domain.Entities;

namespace Infrastructure.Persistance;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        context.Organizations.AddRange(Organization.Create($"code{1}", $"Organization {1}"),
                   Organization.Create($"code{2}", $"Organization {2}"),
                   Organization.Create($"code{3}", $"Organization {3}"));

        context.RolePermissions.AddRange(
           Create(Role.Pases, Domain.Enums.PermissionEnum.AccessPase),
           Create(Role.Pases, Domain.Enums.PermissionEnum.ReadPase),
           Create(Role.Pases, Domain.Enums.PermissionEnum.AddPase),
           Create(Role.Pases, Domain.Enums.PermissionEnum.UpdatePase),
           Create(Role.Pases, Domain.Enums.PermissionEnum.DeletePase)
          );

        context.Users.AddRange(User.Create("agustinyuse@gmail.com", "asasasd"),
        User.Create("test@gmail.com", "asasasd"),
        User.Create("test2@gmail.com", "asasasd"));

        context.SaveChanges();
    }

    private static RolePermission Create(Role role, Domain.Enums.PermissionEnum permission)
    {
        return new RolePermission()
        {
            RoleId = role.Id,
            PermissionId = (int)permission,
        };
    }
}
