using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Miejsce")]
    public class Miejsce
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

    }
}
