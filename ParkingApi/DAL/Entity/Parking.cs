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
        [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ-]{2,40}$", ErrorMessage = "Nazwa może zawierać litery A-z oraz znaki specjalne typu '-'. " +
            "Ponadto musi mieć minimum 2 znaki długości a maximum 40 znaków długości!")]
        public string Nazwa { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z0-9\s\.,-]+$", ErrorMessage = "Niepoprawny format adresu.")]
        public string Adres { get; set; }
        
        public int IdMiasta { get; set; }
        [ForeignKey(nameof(IdMiasta))]

        public Miasto? Miasto { get; set; }

        public ICollection<Opiekun>? Opiekunowie { get; set; }

        public ICollection<Miejsce>? Miejsca { get; set; }


    }
}
