using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class BedAreaEntityTypeConfiguration : IEntityTypeConfiguration<BedArea>
{
    public void Configure(EntityTypeBuilder<BedArea> builder)
    {
        builder.HasKey(x => x.Id).HasName("BedAreaId");
        builder.Property(p => p.BedId).IsRequired();
        builder.Property(p => p.AreaId).IsRequired();
        builder.Property(p => p.OrganizationId).IsRequired();
    }
}
