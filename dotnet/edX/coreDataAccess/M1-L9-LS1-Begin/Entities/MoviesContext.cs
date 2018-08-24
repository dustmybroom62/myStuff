﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MovieApp.Entities
{
    public partial class MoviesContext : DbContext
    {
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmActor> FilmActors { get; set; }
        public virtual DbSet<FilmCategory> FilmCategories { get; set; }
        public virtual DbSet<FilmImage> FilmImages { get; set; }
        public virtual DbSet<FilmInfo> FilmInfos { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        private static MoviesContext _context;
        public static MoviesContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new MoviesContext();
                    // var serviceProvider = _context.GetInfrastructure<IServiceProvider>();
                    // var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                    // loggerFactory.AddProvider(new MyLoggerProvider());
                }
                return _context;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    $"server={Environment.GetEnvironmentVariable("MYSQL_SERVER")}"
                    + $";userid={Environment.GetEnvironmentVariable("MYSQL_UID")}"
                    + $";pwd={Environment.GetEnvironmentVariable("MYSQL_PWD")};"
                    + $"port={Environment.GetEnvironmentVariable("MYSQL_PORT")}"
                    + $";database={Environment.GetEnvironmentVariable("MYSQL_DB")}"
                    + $";sslmode={Environment.GetEnvironmentVariable("MYSQL_SSL")}"
                    + $";");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmInfo>(entity =>
            {
                entity.HasKey(e => new { e.Title, e.ReleaseYear });
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasIndex(e => e.RatingCode)
                    .HasName("film_rating_index");
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor");

                entity.Property(e => e.ActorId)
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("film");

                entity.Property(e => e.FilmId)
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.RatingCode).HasMaxLength(45);

                entity.Property(e => e.ReleaseYear).HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<FilmActor>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.ActorId });

                entity.ToTable("film_actor");

                entity.HasIndex(e => e.ActorId)
                    .HasName("film_actor_actor_idx");

                entity.Property(e => e.FilmId).HasColumnType("int(11)");

                entity.Property(e => e.ActorId).HasColumnType("int(11)");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.FilmActor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_actor_actor");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmActor)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_actor_film");
            });

            modelBuilder.Entity<FilmCategory>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CategoryId });

                entity.ToTable("film_category");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("film_category_category_fk_idx");

                entity.Property(e => e.FilmId).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.FilmCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_category_category_fk");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmCategory)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_category_film_fk");
            });
        }
    }
}
