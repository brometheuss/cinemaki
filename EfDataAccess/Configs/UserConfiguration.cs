using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.FirstName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(u => u.Username)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.HasMany(uc => uc.Cases)
                .WithOne(u => u.User)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
