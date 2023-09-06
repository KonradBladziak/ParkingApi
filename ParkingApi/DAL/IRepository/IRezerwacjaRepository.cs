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
        Task<Rezerwacja> GetByIdAsyncDetails(int id);
        void Add(Rezerwacja rezerwacja);

        void Delete(Rezerwacja rezerwacja);

        void Update(Rezerwacja rezerwacja);

        Task<List<Rezerwacja?>> GetRezerwacjeByIdMiejsca(int id);
        Task<bool> CzyMoznaRezerwowac(int idMiejsca, DateTime Od, DateTime Do, int? idRezerwacji = null);

    }
}
