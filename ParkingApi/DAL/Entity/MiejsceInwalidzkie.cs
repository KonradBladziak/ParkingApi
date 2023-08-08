using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("MiejsceInwalidzkie")]
    public class MiejsceInwalidzkie
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 3)]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal RozmiarMiejsca { get; set; }
        public int IdMiejsca { get; set; }

        [ForeignKey(nameof(IdMiejsca))]
        public Miejsce Miejsce { get; set; }
    }
}
