using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Action)
                .HasMaxLength(512);

            builder.Property(l => l.Date)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(l => l.Success)
                .IsRequired();
        }
    }
}
