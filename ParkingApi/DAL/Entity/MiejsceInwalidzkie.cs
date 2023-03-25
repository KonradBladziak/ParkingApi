using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("MiejsceInwalidzkie")]
    public class MiejsceInwalidzkie : IEntityTypeConfiguration<MiejsceInwalidzkie>
    {
        [Key]
        public int Id { get; set; }
        public decimal RozmiarMiejsca { get; set; }
        public int? IdMiejsca { get; set; }

        [ForeignKey(nameof(IdMiejsca))]
        public Miejsce Miejsce { get; set; }

        public void Configure(EntityTypeBuilder<MiejsceInwalidzkie> builder)
        {
            builder.HasData(
                new MiejsceInwalidzkie()
                {
                    Id = 1,
                    RozmiarMiejsca = 15,
                    IdMiejsca = 3,
                });
        }
    }
}
