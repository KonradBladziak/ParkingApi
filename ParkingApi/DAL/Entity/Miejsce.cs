using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Miejsce")]
    public class Miejsce : IEntityTypeConfiguration<Miejsce>
    {
        [Key]
        public int Id { get; set; }
        public int ParkingId { get; set; }
        [ForeignKey(nameof(ParkingId))]
        public Parking Parking { get; set; }

        public int? MiejsceInwalidzkieId { get; set; }

        [ForeignKey(nameof(MiejsceInwalidzkieId))]
        public MiejsceInwalidzkie? MiejsceInwalidzkie { get; set; }

        public ICollection<Rezerwacja?> Rezerwacje { get; set; }

        public void Configure(EntityTypeBuilder<Miejsce> builder)
        {
            builder.HasData(
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
        }
    }
}
