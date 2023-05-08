using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RolePermissionEntityTypeConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(p => new { p.RoleId, p.PermissionId });

        builder.HasData(
             Create(Role.Registered, Domain.Enums.Permission.AccessProfessional),
             Create(Role.Registered, Domain.Enums.Permission.UpdateProfessional),
             Create(Role.Registered, Domain.Enums.Permission.DeleteProfessional),
             Create(Role.Registered, Domain.Enums.Permission.ReadProfessional),
             Create(Role.Registered, Domain.Enums.Permission.AddProfessional)
            );
    }

    private static RolePermission Create(Role role, Domain.Enums.Permission permission)
    {
        return new RolePermission()
        {
            RoleId = role.Id,
            PermissionId = (int)permission,
        };
    }
}
