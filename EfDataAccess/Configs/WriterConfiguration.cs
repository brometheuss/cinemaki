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
                .HasMaxLength(80)
                .IsRequired();

            builder.HasMany(w => w.MovieWriters)
                .WithOne(w => w.Writer)
                .HasForeignKey(w => w.WriterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
