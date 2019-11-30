using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class ProductionConfiguration : IEntityTypeConfiguration<Production>
    {
        public void Configure(EntityTypeBuilder<Production> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.HasMany(m => m.Movies)
                .WithOne(p => p.Production)
                .HasForeignKey(p => p.ProductionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
