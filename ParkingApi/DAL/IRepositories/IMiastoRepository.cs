using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IMiastoRepository : IDisposable
    {
        
        ICollection<Miasto> GetMiasta();
        ICollection<Parking> GetParkingi(int id);
        Miasto GetMiastoById(int id);
        void InsertMiasto(Miasto miasto);
        void DeleteMiasto(int id);
        void UpdateMiasto(Miasto miasto);
        void Save();

    }
}