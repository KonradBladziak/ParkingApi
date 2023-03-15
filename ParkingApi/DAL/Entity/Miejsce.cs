using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    [Table("Miejsce")]
    public class Miejsce
    {
        [Key]
        public int Id { get; set; }
        public int ParkingId { get; set; }
        [ForeignKey(nameof(ParkingId))]
        public Parking parking { get; set; }

        public int? MiejsceInwalidzkieId { get; set; }

        [ForeignKey(nameof(MiejsceInwalidzkieId))]
        public MiejsceInwalidzkie? MiejsceInwalidzkie { get; set; }

        public ICollection<Rezerwacja?> Rezerwacje { get; set; }
    }
}
