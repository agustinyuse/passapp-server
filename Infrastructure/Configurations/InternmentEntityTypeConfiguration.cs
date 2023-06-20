using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class InternmentEntityTypeConfiguration : IEntityTypeConfiguration<Internment>
{
    public void Configure(EntityTypeBuilder<Internment> builder)
    {
        builder.HasKey(x => x.Id).HasName("InternmentId"); ;
        builder.Property(x => x.PatientId).IsRequired();
        builder.Property(x => x.AdmissionDate).IsRequired();
        builder.Property(x => x.DischargeDate).IsRequired();
    }
}
