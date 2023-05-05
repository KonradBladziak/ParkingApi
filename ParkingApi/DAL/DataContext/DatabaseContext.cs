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
        public DatabaseContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Parking;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Miasto> Miasta { get; set; }
        public DbSet<Parking> Parkingi { get; set; }
        public DbSet<Miejsce> Miejsca { get; set; }
        public DbSet<MiejsceInwalidzkie> MiesjcaInwalidzkie { get; set; }
        public DbSet<Opiekun> Opiekunowie { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
    }
}
