using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IMiejsceRepository : IDisposable
    {
        Task <ICollection<Miejsce>> GetMiejsca();
        Task <ICollection<Rezerwacja>> GetRezerwacje();
        Task <Miejsce> GetMiejscaById(int? id);
        Task InsertMiejsce(Miejsce miejsce);
        Task UpdateMiejsce(Miejsce miejsce);
        Task DeleteMiejsce(Miejsce miejsce);
        Task Save();
    }
}
