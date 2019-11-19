using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.IsActive)
                .HasDefaultValue(true);

            builder.Property(r => r.IsDeleted)
                .HasDefaultValue(false);

            builder.HasMany(rc => rc.ReservationSeats)
                .WithOne(rs => rs.Reservation)
                .HasForeignKey(rs => rs.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}