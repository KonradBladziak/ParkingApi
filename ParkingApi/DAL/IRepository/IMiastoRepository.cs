using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IMiastoRepository : IRepository<Miasto>
    {
        Task<IEnumerable<Miasto>> GetAllAsync();
        Task<Miasto> GetByIdAsync(int id);

        Task AddAsync(Miasto miasto);

        Task DeleteAsync(Miasto miasto);

        Task UpdateAsync(Miasto miasto);
        
    }
}
