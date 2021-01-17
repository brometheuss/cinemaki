using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(s => s.IsBroken)
                .HasDefaultValue(true);

            builder.HasMany(rs => rs.ReservationSeats)
                .WithOne(rs => rs.Seat)
                .HasForeignKey(rs => rs.SeatId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
