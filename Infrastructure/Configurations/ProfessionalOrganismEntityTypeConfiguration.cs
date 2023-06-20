using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class ProfessionalOrganizationEntityTypeConfiguration : IEntityTypeConfiguration<ProfessionalOrganization>
{
    public void Configure(EntityTypeBuilder<ProfessionalOrganization> builder)
    {
        builder.HasKey(p => p.Id).HasName("ProfessionalOrganizationId");
    }
}
