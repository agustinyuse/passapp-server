using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(p => p.PermissionId);

        IEnumerable<Permission> permissions = Enum.GetValues<Domain.Enums.Permission>().Select(p => new Permission()
        {
            PermissionId = (int)p,
            Name = p.ToString()
        });

        builder.HasData(permissions);
    }
}
