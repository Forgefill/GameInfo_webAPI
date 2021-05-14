using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Lab2ICTP.Models
{
    public class DBGameContext : DbContext
    {
        public virtual DbSet<Country> Countries {get;set;}

        public virtual DbSet<Developer> Developers { get; set; }

        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<ESRB> ESRBs { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<GamesGenres> GamesGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        public DBGameContext(DbContextOptions<DBGameContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasOne(e => e.Country)
                .WithMany(e => e.Publishers)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publishers_Countries");

                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.HasOne(e => e.Country)
                .WithMany(e => e.Developers)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Developers_Countries");

                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<ESRB>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            });


            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(e => e.Series)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.SeriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_Series");

                entity.HasOne(e => e.Developer)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_Developers");

                entity.HasOne(e => e.Publisher)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_Publishers");

                entity.HasOne(e => e.ESRB)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.ESRBId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_ESRBs");

                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();

                entity.Property(e => e.Rating).IsRequired();

                entity.Property(e => e.RealeseDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<GamesGenres>(entity =>
            {

                entity.HasOne(e => e.Game)
                .WithMany(e => e.GamesGenres)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GamesGanres_Games");

                entity.HasOne(e => e.Genre)
                .WithMany(e => e.GamesGenres)
                .HasForeignKey(e => e.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GamesGanres_Genres");

            });
        }

    }
}
