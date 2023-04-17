using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IRezerwacjaRepository : IDisposable
    {
        Task <IEnumerable<Rezerwacja>> GetRezerwacje();
        Task <Rezerwacja> GetRezerwacjaById(int id);
        Task InsertRezerwacja(Rezerwacja rezerwacja);
        Task UpdateRezerwacja(Rezerwacja rezerwacja);
        Task DeleteRezerwacja(int id);
        Task Save();
    }
}
