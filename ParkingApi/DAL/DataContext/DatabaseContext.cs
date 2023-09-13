using Castle.Core.Internal;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Miasto> Miasta { get; set; }
        public DbSet<Parking> Parkingi { get; set; }
        public DbSet<Miejsce> Miejsca { get; set; }
        public DbSet<MiejsceInwalidzkie> MiesjcaInwalidzkie { get; set; }
        public DbSet<Opiekun> Opiekunowie { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }

        public DatabaseContext() : base() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options){ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=172.19.174.216;Initial Catalog=Parking;User ID=sa;Password=Password123;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Jedno Miasto do wielu Parkingów
            modelBuilder.Entity<Miasto>()
                .HasMany(x => x.Parkingi)
                .WithOne(x => x.Miasto)
                .HasForeignKey(x => x.IdMiasta)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Wiele Parkingów do wielu Opiekunów
            modelBuilder.Entity<Parking>()
                .HasMany(x => x.Opiekunowie)
                .WithMany(x => x.Parkingi)
                .UsingEntity(x => x.ToTable("ParkingOpiekun"));

            //Wiele miejsc do jednego Parkingu
            modelBuilder.Entity<Miejsce>()
                .HasOne(x => x.Parking)
                .WithMany(x => x.Miejsca)
                .HasForeignKey(x => x.ParkingId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            //Jeden opis MiejscaInwalidzkiego do Miejsca
            modelBuilder.Entity<MiejsceInwalidzkie>()
                .HasOne(x => x.Miejsce)
                .WithOne(x => x.MiejsceInwalidzkie)
                .HasForeignKey<MiejsceInwalidzkie>(x => x.IdMiejsca)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Wiele rezerwacji do jednego miejsca
            modelBuilder.Entity<Rezerwacja>()
                .HasOne(x=>x.Miejsce)
                .WithMany(x => x.Rezerwacje)
                .HasForeignKey(x => x.IdMiejsca)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Miasto>().HasData(
                new Miasto()
                {
                    Id = 1,
                    Nazwa = "Katowice",
                    Wojewodztwo = "Slaskie",
                },
                new Miasto()
                {
                    Id = 2,
                    Nazwa = "Chorzow",
                    Wojewodztwo = "Slaskie",
                },
                new Miasto()
                {
                    Id = 3,
                    Nazwa = "Bytom",
                    Wojewodztwo = "Slaskie",
                }
                );

            modelBuilder.Entity<Parking>().HasData(
                    new Parking()
                    {
                        Id = 1,
                        Nazwa = "Slaski",
                        Adres = "Kolejowa 16",
                        IdMiasta = 1
                    },
                    new Parking()
                    {
                        Id = 2,
                        Nazwa = "Chorzowski",
                        Adres = "Wesoła 21",
                        IdMiasta = 2
                    },
                    new Parking()
                    {
                        Id = 3,
                        Nazwa = "Na zakręcie",
                        Adres = "Jana Pawła II 51",
                        IdMiasta = 1
                    },
                    new Parking()
                    {
                        Id = 4,
                        Nazwa = "Przy galerii",
                        Adres = "Grzybowa 11",
                        IdMiasta = 3
                    }
                    );

            modelBuilder.Entity<Opiekun>().HasData(
                new Opiekun()
                {
                    Id = 1,
                    Imie = "Michał",
                    Nazwisko = "Czajkowski"
                },
                 new Opiekun()
                 {
                     Id = 2,
                     Imie = "Konrad",
                     Nazwisko = "Bladziak"
                 });

            modelBuilder.Entity<Miejsce>().HasData(
                new Miejsce
                {
                    Id = 1,
                    ParkingId = 1,
                    MiejsceInwalidzkieId = 1,
                },
                new Miejsce
                {
                    Id = 2,
                    ParkingId = 3,
                    MiejsceInwalidzkieId = null,
                },
                new Miejsce
                {
                    Id = 3,
                    ParkingId = 2,
                    MiejsceInwalidzkieId = null,
                });

            modelBuilder.Entity<MiejsceInwalidzkie>().HasData(
                new MiejsceInwalidzkie()
                {
                    Id = 1,
                    RozmiarMiejsca = 15,
                    IdMiejsca = 2,
                });

            modelBuilder.Entity<Rezerwacja>().HasData(
                new Rezerwacja()
                {
                    Id = 1,
                    Od = new DateTime(2023, 7, 12, 14, 0, 0),
                    Do = new DateTime(2023, 7, 12, 15, 0, 0),
                    IdMiejsca = 2,
                    Imie = "Maciej",
                    Nazwisko = "Grzybowski"
                });
        }
    }
}
