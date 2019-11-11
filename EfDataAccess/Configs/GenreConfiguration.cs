using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(g => g.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(g => g.IsActive)
                .HasDefaultValue(true);

            builder.Property(g => g.IsDeleted)
                .HasDefaultValue(false);

            builder.HasMany(g => g.MovieGenres)
                .WithOne(g => g.Genre)
                .HasForeignKey(g => g.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
