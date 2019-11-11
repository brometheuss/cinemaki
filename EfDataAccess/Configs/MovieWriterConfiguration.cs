using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class MovieWriterConfiguration : IEntityTypeConfiguration<MovieWriter>
    {
        public void Configure(EntityTypeBuilder<MovieWriter> builder)
        {
            builder.HasKey(mw => new
            {
                mw.MovieId,
                mw.WriterId
            });
        }
    }
}
