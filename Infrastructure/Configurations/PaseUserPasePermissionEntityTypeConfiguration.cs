using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class PaseUserPasePermissionEntityTypeConfiguration : IEntityTypeConfiguration<PaseUserPasePermission>
{
    public void Configure(EntityTypeBuilder<PaseUserPasePermission> builder)
    {
        builder.HasKey(p => p.Id).HasName("PaseUserPasePermissionId");
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.PaseId).IsRequired();
        builder.Property(p => p.PasePermissionId).IsRequired();
    }
}
