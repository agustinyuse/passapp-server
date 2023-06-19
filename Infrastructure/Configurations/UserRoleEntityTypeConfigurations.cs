using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;

internal class UserRoleEntityTypeConfigurations : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(p => p.Id).HasName("UserRoleId");

        builder.Property(p => p.CreatedUserId).HasDefaultValue(1);
        builder.Property(p => p.DateCreated).HasDefaultValue(DateTime.UtcNow);
    }
}
