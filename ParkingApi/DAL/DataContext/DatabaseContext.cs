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
        private readonly IConfiguration configuration_;

        public DatabaseContext(IConfiguration configuration)
        {
            configuration_ = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration_.GetConnectionString("Database"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Miasto>().Property(x => x.Nazwa).ValueGeneratedOnAddOrUpdate();
            
        }

        public DbSet<Miasto> Miasta { get; set; }
        public DbSet<Parking> Parkingi { get; set; }
        public DbSet<Miejsce> Miejsca { get; set; }
        public DbSet<MiejsceInwalidzkie> MiesjcaInwalidzkie { get; set; }
        public DbSet<Opiekun> Opiekunowie { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
    }
}
