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
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(s => s.IsBroken)
                .HasDefaultValue(true);

            builder.Property(s => s.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);

            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);

            builder.HasMany(rs => rs.ReservationSeats)
                .WithOne(rs => rs.Seat)
                .HasForeignKey(rs => rs.SeatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
