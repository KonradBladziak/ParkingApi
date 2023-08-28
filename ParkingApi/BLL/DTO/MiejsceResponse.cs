using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.DTO
{
    public class MiejsceResponse
    {
        public int IdMiejsca { get; set; }
        public int? IdMiejscaInwalidzkiego { get; set; }
        public decimal? RozmiarMiejscaInwalidzkiego { get; set; }
        public bool CzyDostepne { get; set; }
    }
}
