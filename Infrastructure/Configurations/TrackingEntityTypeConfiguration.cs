using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrackingEntityTypeConfiguration : IEntityTypeConfiguration<Tracking>
{
    public void Configure(EntityTypeBuilder<Tracking> builder)
    {
        builder.HasKey(x => x.Id).HasName("TrackingId");
        builder.Property(p => p.InternmentId).IsRequired();
        builder.Property(p => p.Date).HasDefaultValue(DateTime.UtcNow);
    }
}
