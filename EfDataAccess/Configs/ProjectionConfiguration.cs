﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DateBegin)
                .IsRequired();

            builder.Property(p => p.DateEnd)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
