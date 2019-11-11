using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configs
{
    public class MovieLanguageConfiguration : IEntityTypeConfiguration<MovieLanguage>
    {
        public void Configure(EntityTypeBuilder<MovieLanguage> builder)
        {
            builder.HasKey(ml => new
            {
                ml.MovieId,
                ml.LanguageId
            });
        }
    }
}
