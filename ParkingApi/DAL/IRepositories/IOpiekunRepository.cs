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
        Task <IEnumerable<Opiekun>> GetOpiekunowie();
        Task <ICollection<Parking>> GetParkingi(int id);
        Task <Opiekun> GetOpiekunById(int id);
        Task InsertOpiekun(Opiekun opiekun);
        Task DeleteOpiekun(int id);
        Task UpdateOpiekun(Opiekun opiekun);
        Task Save();

    }
}
