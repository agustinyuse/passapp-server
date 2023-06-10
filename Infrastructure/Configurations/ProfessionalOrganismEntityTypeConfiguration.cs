using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProfessionalOrganismEntityTypeConfiguration : IEntityTypeConfiguration<ProfessionalOrganism>
{
    public void Configure(EntityTypeBuilder<ProfessionalOrganism> builder)
    {
        builder.HasKey(p => p.Id);
    }
}
