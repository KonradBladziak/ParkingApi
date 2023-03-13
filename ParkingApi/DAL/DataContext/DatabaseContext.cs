using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel;
using System.Reflection;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild() 
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = opsBuilder.Options;

            }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
            public AppConfiguration settings { get; set; }
        }
        
        public static OptionsBuild ops = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }

        public DbSet<Miasto> Miasta { get; set; }
        public DbSet<Parking> Parkingi { get; set; }
        public DbSet<Miejsce> Miejsca { get; set; }
        public DbSet<MiejsceInwalidzkie> MiesjcaInwalidzkie { get; set; }
        public DbSet<Opiekun> Opiekunowie { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }

        //private readonly IConfiguration configuration_;

        //public DatabaseContext(IConfiguration configuration)
        //{
        //    configuration_ = configuration;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(configuration_.GetConnectionString("Database"));

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}


    }
}
