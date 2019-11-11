using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class RatedConfiguration : IEntityTypeConfiguration<Rated>
    {
        public void Configure(EntityTypeBuilder<Rated> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.IsActive)
                .HasDefaultValue(true);

            builder.Property(r => r.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
