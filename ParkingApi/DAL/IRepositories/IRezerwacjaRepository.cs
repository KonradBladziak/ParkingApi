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
        ICollection<Rezerwacja> GetRezerwacje();
        Rezerwacja GetRezerwacjaById(int id);
        void AddRezerwacja(Rezerwacja rezerwacja);
        void UpdateRezerwacja(Rezerwacja rezerwacja);
        void DeleteRezerwacja(int id);
        void Save();
    }
}
