using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public abstract class Osoba
    {
        [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ-]{2,40}$", ErrorMessage = "Imię może zawierać litery A-z oraz znaki specjalne typu '-'. " +
            "Ponadto musi mieć minimum 2 znaki długości a maximum 40 znaków długości!")]
        public string Imie { get; set; }
        [RegularExpression(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ-]{2,40}$", ErrorMessage = "Nazwisko może zawierać litery A-z oraz znaki specjalne typu '-'. " +
            "Ponadto musi mieć minimum 2 znaki długości a maximum 40 znaków długości!")]
        public string Nazwisko { get; set; }
    }
}
