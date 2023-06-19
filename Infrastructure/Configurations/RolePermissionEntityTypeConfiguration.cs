using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RolePermissionEntityTypeConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(p => p.Id).HasName("RolePermissionId");

        builder.Property(p => p.CreatedUserId).HasDefaultValue(1);
        builder.Property(p => p.DateCreated).HasDefaultValue(DateTime.UtcNow);
    }
}
