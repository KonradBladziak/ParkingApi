using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IParkingRepository : IDisposable
    {
        Task<ICollection<Parking>> GetParkingi();
        Task<Parking> GetParkingById(int? id);
        Task InsertParking(Parking parking);
        Task UpdateParking(Parking parking);
        Task DeleteParking(Parking parking);
        Task Save();
    }
}
