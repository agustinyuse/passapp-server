using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Id).HasName("UserId");
        builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Password).IsRequired().HasMaxLength(50);
        builder.Property(p => p.CreatedUserId).HasDefaultValue(1);
        builder.Property(p => p.DateCreated).HasDefaultValue(DateTime.UtcNow);
    }
}
