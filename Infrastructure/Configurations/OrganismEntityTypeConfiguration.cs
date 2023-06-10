using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class OrganismEntityTypeConfiguration : IEntityTypeConfiguration<Organism>
{
    public void Configure(EntityTypeBuilder<Organism> builder)
    {
        builder.HasKey(p => p.Id);
    }
}
