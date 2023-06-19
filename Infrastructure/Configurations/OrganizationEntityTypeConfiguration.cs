using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class OrganizationEntityTypeConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(p => p.Id).HasName("OrganizationId");
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Code).IsRequired().HasMaxLength(20);

        builder.Property(p => p.CreatedUserId).HasDefaultValue(1);
        builder.Property(p => p.DateCreated).HasDefaultValue(DateTime.UtcNow);
    }
}
