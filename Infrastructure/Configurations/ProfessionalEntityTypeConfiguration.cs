using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class ProfessionalEntityTypeConfiguration : IEntityTypeConfiguration<Professional>
{
    public void Configure(EntityTypeBuilder<Professional> builder)
    {
        builder.HasKey(x => x.Id).HasName("ProfessionalId");
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);

        builder.OwnsMany(p => p.Addresses);
    }
}
