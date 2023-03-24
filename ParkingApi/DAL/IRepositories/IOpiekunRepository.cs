using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IOpiekunRepository : IDisposable
    {
        ICollection<Opiekun> GetOpiekunowie();
        ICollection<Parking> GetParkingi(int id);
        Opiekun GetOpiekunById(int id);
        void InsertOpiekun(Opiekun opiekun);
        void DeleteOpiekun(int id);
        void UpdateOpiekun(Opiekun opiekun);
        void Save();

    }
}
