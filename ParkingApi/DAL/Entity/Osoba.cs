using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public abstract class Osoba
    {
        [RegularExpression(@"^[a-zA-Z'-'\s]{1,40}$")]
        public string Imie { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Nazwisko { get; set; }
    }
}
