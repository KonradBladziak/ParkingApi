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
        ICollection<Miejsce> GetMiejsca();
        ICollection<Rezerwacja> GetRezerwacje();
        Miejsce GetMiejscaById(int id);
        void AddMiejsce(Miejsce miejsce);
        void UpdateMiejsce(Miejsce miejsce);
        void DeleteMiejsce(int id);
        void Save();
    }
}
