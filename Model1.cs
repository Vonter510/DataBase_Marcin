namespace DataBase_Marcin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<adresy> adresy { get; set; }
        public virtual DbSet<klienci> klienci { get; set; }
        public virtual DbSet<pracownicy> pracownicy { get; set; }
        public virtual DbSet<samochody> samochody { get; set; }
        public virtual DbSet<wypozyczenia> wypozyczenia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adresy>()
                .Property(e => e.Miasto)
                .IsFixedLength();

            modelBuilder.Entity<adresy>()
                .Property(e => e.Ulica)
                .IsFixedLength();

            modelBuilder.Entity<adresy>()
                .Property(e => e.Nr_domu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<adresy>()
                .Property(e => e.Kod_pocztowy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<klienci>()
                .Property(e => e.Imie)
                .IsFixedLength();

            modelBuilder.Entity<klienci>()
                .Property(e => e.Nazwisko)
                .IsFixedLength();

            modelBuilder.Entity<klienci>()
                .Property(e => e.Nr_komorkowy)
                .IsUnicode(false);

            modelBuilder.Entity<klienci>()
                .Property(e => e.Pesel)
                .IsUnicode(false);

            modelBuilder.Entity<klienci>()
                .HasMany(e => e.wypozyczenia)
                .WithRequired(e => e.klienci)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pracownicy>()
                .Property(e => e.Imie)
                .IsFixedLength();

            modelBuilder.Entity<pracownicy>()
                .Property(e => e.Nazwisko)
                .IsFixedLength();

            modelBuilder.Entity<pracownicy>()
                .Property(e => e.Pesel)
                .IsUnicode(false);

            modelBuilder.Entity<pracownicy>()
                .HasMany(e => e.wypozyczenia)
                .WithRequired(e => e.pracownicy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<samochody>()
                .Property(e => e.Marka)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<samochody>()
                .Property(e => e.Model)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<samochody>()
                .Property(e => e.Nr_rejestracyjny)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<samochody>()
                .Property(e => e.VIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<samochody>()
                .HasMany(e => e.wypozyczenia)
                .WithRequired(e => e.samochody)
                .WillCascadeOnDelete(false);
        }
    }
}
