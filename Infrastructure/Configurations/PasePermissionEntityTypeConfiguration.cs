using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class PasePermissionEntityTypeConfiguration : IEntityTypeConfiguration<PasePermission>
{
    public void Configure(EntityTypeBuilder<PasePermission> builder)
    {
        builder.HasKey(x => x.Id).HasName("PasePermissionId");
        builder.HasData(PasePermission.GetValues);
    }
}
