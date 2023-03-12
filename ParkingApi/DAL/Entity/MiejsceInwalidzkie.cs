using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    [Table("MiejsceInwalidzkie")]
    public class MiejsceInwalidzkie
    {
        [Key]
        public int Id { get; set; }
        public decimal RozmiarMiejsca { get; set; }
        public int? IdMiejsca { get; set; }

        [ForeignKey(nameof(Miejsce))]
        public Miejsce miejsce { get; set; }
    }
}
