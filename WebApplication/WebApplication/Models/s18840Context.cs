using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public partial class s18840Context : DbContext
    {
        public s18840Context()
        {
        }

        public s18840Context(DbContextOptions<s18840Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(x => x.IdKlient)
                    .HasName("Klient_pk")
                    .IsClustered(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(x => x.IdPracownik)
                    .HasName("Pracownik_pk")
                    .IsClustered(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<WyrobCukierniczy>(entity =>
            {
                entity.HasKey(x => x.IdWyrobuCukierniczego)
                    .HasName("WyrobCukierniczy_pk")
                    .IsClustered(false);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(x => x.IdZamowienia)
                    .HasName("Zamowienie_pk")
                    .IsClustered(false);

                entity.Property(e => e.DataPrzyjecia).HasColumnType("datetime");

                entity.Property(e => e.DataRealizacji).HasColumnType("datetime");

                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(d => d.IdVirtualKlient)
                    .WithMany(p => p.Zamowienia)
                    .HasForeignKey(x => x.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdKlient");

                entity.HasOne(d => d.IdVirtualPracownik)
                    .WithMany(p => p.Zamowienia)
                    .HasForeignKey(x => x.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdPracownik");
            });

            modelBuilder.Entity<ZamowienieWyrobCukierniczy>(entity =>
            {
                entity.HasKey(x => new { x.IdWyrobuCukierniczego, x.IdZamowienia })
                    .HasName("Zamowienie_WyrobCukierniczy_pk")
                    .IsClustered(false);

                entity.ToTable("Zamowienie_WyrobCukierniczy");

                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(d => d.IdVirtualWyrobCukierniczy)
                    .WithMany(p => p.Zamowienie_WyrobCukierniczy)
                    .HasForeignKey(x => x.IdWyrobuCukierniczego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdWyrobuCukierniczego");

                entity.HasOne(d => d.IdVirtualZamowienie)
                    .WithMany(p => p.Zamowienie_WyrobyCukiernicze)
                    .HasForeignKey(x => x.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdZamowienia");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

