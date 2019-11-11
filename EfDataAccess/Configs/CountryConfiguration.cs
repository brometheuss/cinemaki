using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.Property(c => c.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
