using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(m => m.LengthMinutes)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(m => m.Plot)
                .IsRequired();

            builder.Property(m => m.DebutDate)
                .IsRequired();

            builder.HasMany(m => m.MovieGenres)
                .WithOne(m => m.Movie)
                .HasForeignKey(m => m.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ma => ma.MovieActors)
                .WithOne(ma => ma.Movie)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.MovieLanguages)
                .WithOne(m => m.Movie)
                .HasForeignKey(m => m.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(mw => mw.MovieWriters)
                .WithOne(mw => mw.Movie)
                .HasForeignKey(mw => mw.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
