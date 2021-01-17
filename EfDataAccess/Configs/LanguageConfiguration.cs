using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasIndex(l => l.Name)
                .IsUnique();

            builder.Property(l => l.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.HasMany(l => l.MovieLanguages)
                .WithOne(l => l.Language)
                .HasForeignKey(l => l.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
