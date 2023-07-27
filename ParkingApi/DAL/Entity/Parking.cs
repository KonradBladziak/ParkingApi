using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Parking")]
    public class Parking
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nazwa { get; set; }

        [MaxLength(50)]
        public string Adres { get; set; }
        
        public int IdMiasta { get; set; }
        [ForeignKey(nameof(IdMiasta))]

        public Miasto? Miasto { get; set; }

        public ICollection<Opiekun>? Opiekunowie { get; set; }

        public ICollection<Miejsce>? Miejsca { get; set; }


    }
}
