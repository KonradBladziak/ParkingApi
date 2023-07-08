using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

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


        public DatabaseContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Parking;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

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
                .HasForeignKey<MiejsceInwalidzkie>(x => x.IdMiejsca);

        
        }


        

        ModelBuilder 
    }
}
