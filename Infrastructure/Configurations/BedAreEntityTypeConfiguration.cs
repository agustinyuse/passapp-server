using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class BedAreEntityTypeConfiguration : IEntityTypeConfiguration<BedArea>
{
    public void Configure(EntityTypeBuilder<BedArea> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
