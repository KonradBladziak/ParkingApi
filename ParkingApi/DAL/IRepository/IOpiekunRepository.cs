using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IOpiekunRepository : IRepository<Opiekun>
    {
        Task<IEnumerable<Opiekun>> GetAllAsync();
        Task<Opiekun> GetByIdAsync(int id);

        void Add(Opiekun opiekun);

        void Delete(Opiekun opiekun);

        void Update(Opiekun opiekun);

    }
}
