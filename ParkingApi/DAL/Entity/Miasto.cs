using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Miasto")]
    public class Miasto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nazwa { get; set; }

        [MaxLength(50)]
        public string Wojewodztwo { get; set; }

        public ICollection<Parking>? Parkingi { get; set; }

    }
}
