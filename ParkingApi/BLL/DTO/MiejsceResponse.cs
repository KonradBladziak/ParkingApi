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
        int IdMiejsca { get; set; }
        int? IdMiejscaInwalidzkiego { get; set; }
        decimal? RozmiarMiejscaInwalidzkiego { get; set; }
        bool CzyDostepne { get; set; }
    }
}
