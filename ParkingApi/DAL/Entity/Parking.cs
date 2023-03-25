using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Parking")]
    public class Parking : IEntityTypeConfiguration<Parking>
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nazwa { get; set; }

        [MaxLength(50)]
        public string Adres { get; set; }

        public int IdMiasta { get; set; }
        [ForeignKey(nameof(IdMiasta))]
        public Miasto Miasto { get; set; }

        public ICollection<Opiekun> Opiekunowie { get; set; }

        public ICollection<Miejsce> Miejsca { get; set; }

        public void Configure(EntityTypeBuilder<Parking> builder)
        {
            builder.HasData(
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
        }
    }
}
