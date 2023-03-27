using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IMiastoRepository : IDisposable
    {
        
        Task<IEnumerable<Miasto>> GetMiasta();
        Task<ICollection<Parking>> GetParkingi(int id);
        Task <Miasto> GetMiastoById(int? id);
        Task InsertMiasto(Miasto miasto);
        Task DeleteMiasto(int? id);
        Task UpdateMiasto(Miasto miasto);
        Task Save();

    }
}