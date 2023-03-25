using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Miasto")]
    public class Miasto : IEntityTypeConfiguration<Miasto>
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nazwa { get; set; }

        [MaxLength(50)]
        public string Wojewodztwo { get; set; }

        public ICollection<Parking>? Parkingi { get; set; }

        public void Configure(EntityTypeBuilder<Miasto> builder)
        {
            builder.HasData(
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

        }
    }
}
