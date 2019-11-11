using Domain;
using EfDataAccess.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess
{
    public class EfCinemakContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Rated> Rateds { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MovieWriter> MovieWriters { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HAH0RJ9\SQLEXPRESS;Initial Catalog=Cinemak;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new RatedConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieActorConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new MovieWriterConfiguration());
            modelBuilder.ApplyConfiguration(new WriterConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionConfiguration());
            modelBuilder.ApplyConfiguration(new PosterConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
        }
    }
}
