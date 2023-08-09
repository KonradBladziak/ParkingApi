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
        [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ-]{2,40}$", ErrorMessage = "Nazwa miasta może zawierać litery A-z oraz znaki specjalne typu '-'. " +
            "Ponadto musi mieć minimum 2 znaki długości a maximum 40 znaków długości!")]
        public string Nazwa { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ-]{2,20}$", ErrorMessage = "Nazwa województwa może zawierać litery A-z oraz znaki specjalne typu '-'. " +
            "Ponadto musi mieć minimum 2 znaki długości a maximum 20 znaków długości!")]
        public string Wojewodztwo { get; set; }

        public ICollection<Parking>? Parkingi { get; set; }

    }
}
