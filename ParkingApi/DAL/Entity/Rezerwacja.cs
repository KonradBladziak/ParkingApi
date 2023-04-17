using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Rezerwacja")]
    public class Rezerwacja : Osoba, IEntityTypeConfiguration<Rezerwacja>
    {
        [Key]
        public int Id { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public int IdMiejsca { get; set; }

        [ForeignKey(nameof(IdMiejsca))]
        public Miejsce Miejsce { get; set; }

        public void Configure(EntityTypeBuilder<Rezerwacja> builder)
        {
            builder.HasData(
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
