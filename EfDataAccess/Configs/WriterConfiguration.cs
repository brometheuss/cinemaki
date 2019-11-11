using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(w => w.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(w => w.IsActive)
                .HasDefaultValue(true);

            builder.Property(w => w.IsDeleted)
                .HasDefaultValue(false);

            builder.HasMany(w => w.MovieWriters)
                .WithOne(w => w.Writer)
                .HasForeignKey(w => w.WriterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
