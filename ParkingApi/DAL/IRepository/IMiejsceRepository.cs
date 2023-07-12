using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IMiejsceRepository : IRepository<Miejsce>
    {
        Task<IEnumerable<Miejsce>> GetAllAsync();
        Task<Miejsce> GetByIdAsync(int id);

        void Add(Miejsce miejsce);

        void Delete(Miejsce miejsce);

        void Update(Miejsce miejsce);

    }
}
