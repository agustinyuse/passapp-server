using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class InternmentEntityTypeConfiguration : IEntityTypeConfiguration<Internment>
{
    public void Configure(EntityTypeBuilder<Internment> builder)
    {
       builder.HasKey(x => x.Id);
    }
}
