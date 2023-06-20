using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class BedEntityTypeConfiguration : IEntityTypeConfiguration<Bed>
{
    public void Configure(EntityTypeBuilder<Bed> builder)
    {
        builder.HasKey(p=> p.Id).HasName("BedId"); ;
        builder.Property(p => p.Code).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
    }
}
