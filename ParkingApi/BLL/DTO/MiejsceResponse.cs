using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MiejsceResponse
    {
        public int Id { get; set; }
        public int? MiejsceInwalidzkieId { get; set; }
        public decimal RozmiarMiejscaInwalidzkiego { get; set; }
    }
}
