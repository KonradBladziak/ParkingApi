using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IRezerwacjaRepository : IRepository<Rezerwacja>
    {
        Task<IEnumerable<Rezerwacja>> GetAllAsync();
        Task<Rezerwacja> GetByIdAsync(int id);

        void Add(Rezerwacja rezerwacja);

        void Delete(Rezerwacja rezerwacja);

        void Update(Rezerwacja rezerwacja);

    }
}
