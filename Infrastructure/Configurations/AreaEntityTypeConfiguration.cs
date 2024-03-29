﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class AreaEntityTypeConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasKey(p => p.Id).HasName("AreaId");
        builder.Property(p => p.Code).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
    }
}
