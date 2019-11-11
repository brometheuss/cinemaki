using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Text)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.IsActive)
                .HasDefaultValue(false);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
