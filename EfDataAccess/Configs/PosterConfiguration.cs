using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class PosterConfiguration : IEntityTypeConfiguration<Poster>
    {
        public void Configure(EntityTypeBuilder<Poster> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PosterTitle)
                .HasMaxLength(100);

            builder.Property(p => p.Alt)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
