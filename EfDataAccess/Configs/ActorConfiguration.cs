using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(a => a.MovieActors)
                .WithOne(a => a.Actor)
                .HasForeignKey(a => a.ActorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
