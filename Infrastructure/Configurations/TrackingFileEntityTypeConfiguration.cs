using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class TrackingFileEntityTypeConfiguration : IEntityTypeConfiguration<TrackingFile>
{
    public void Configure(EntityTypeBuilder<TrackingFile> builder)
    {
        builder.HasKey(t => t.Id).HasName("TrackingFileId");
        builder.Property(p => p.FileName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.FileType).IsRequired();
        builder.Property(p => p.FileSize).IsRequired();
        builder.Property(p => p.Path).IsRequired().HasMaxLength(100);
    }
}
