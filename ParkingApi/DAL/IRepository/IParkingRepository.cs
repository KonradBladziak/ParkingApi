using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IParkingRepository : IRepository<Parking>
    {

        Task<IEnumerable<Parking>> GetAllAsync();
        Task<Parking> GetByIdAsync(int id);

        Task<Parking> GetByIdDetailsAsync(int id);

        Task<IEnumerable<Parking>> GetByIdMiasta(int idMiasta);

        void Add(Parking parking);

        void Delete(Parking parking);

        void Update(Parking parking);

        Task UsunOpiekuna(int parkingId, int opiekunId);
    }
}
