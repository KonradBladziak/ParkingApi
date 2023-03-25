using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    public abstract class Osoba
    {
        public string Imie { get; set; }

        public string Nazwisko { get; set; }
    }
}
