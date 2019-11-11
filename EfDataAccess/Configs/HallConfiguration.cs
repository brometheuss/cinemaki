using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasIndex(h => h.Name)
                .IsUnique();

            builder.Property(h => h.Name)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(h => h.MaximumOccupancy)
                .IsRequired();

            builder.Property(h => h.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(h => h.IsActive)
                .HasDefaultValue(true);

            builder.Property(h => h.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
