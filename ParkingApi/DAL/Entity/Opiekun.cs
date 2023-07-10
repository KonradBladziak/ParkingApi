using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    [Table("Opiekun")]
    public class Opiekun : Osoba
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Parking> Parkingi { get; set; }
    }
}
