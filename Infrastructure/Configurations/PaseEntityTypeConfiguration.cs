using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class PaseEntityTypeConfiguration : IEntityTypeConfiguration<Pase>
{
    public void Configure(EntityTypeBuilder<Pase> builder)
    {
        builder.HasKey(x => x.Id).HasName("PaseId");
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.OrganizationId).IsRequired();
    }
}
