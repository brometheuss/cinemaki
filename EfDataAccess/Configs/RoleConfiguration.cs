using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasIndex(r => r.Name)
                .IsUnique();

            builder.Property(r => r.Name)
                .HasMaxLength(20)
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
