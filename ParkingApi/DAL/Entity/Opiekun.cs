using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    [Table("Opiekun")]
    public class Opiekun : Osoba, IEntityTypeConfiguration<Opiekun>
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Parking> Parkingi { get; set; }

        public void Configure(EntityTypeBuilder<Opiekun> builder)
        {
            builder.HasData(
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
        }
    }
}
