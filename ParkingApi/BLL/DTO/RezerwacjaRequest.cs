using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RezerwacjaRequest
    {
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public int IdMiejsca { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
