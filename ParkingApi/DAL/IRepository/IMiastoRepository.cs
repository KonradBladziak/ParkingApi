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
        Task<Miasto> GetByIdAsyncDetails(int id);

        void Add(Miasto miasto);

        void Delete(Miasto miasto);

        void Update(Miasto miasto);
        
    }
}
