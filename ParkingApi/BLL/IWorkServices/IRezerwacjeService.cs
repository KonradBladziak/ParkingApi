using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IWorkServices
{
    public interface IRezerwacjeService
    {
        Task<IEnumerable<Rezerwacja>> GetRezerwacje();
        Task<Rezerwacja> GetRezerwacjaById(int id);
        Task<Rezerwacja> GetRezerwacjaByIdDetails(int id);
        Task AddRezerwacja(Rezerwacja rezerwacja);
        Task DeleteRezerwacja(Rezerwacja rezerwacja);
        Task UpdateRezerwacja(Rezerwacja rezerwacja);
    }
}
