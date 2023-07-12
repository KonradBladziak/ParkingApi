using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IWorkServices
{
    public interface IParkingService
    {
        Task<List<Parking>> GetParkingi();
        Task<Parking> GetParkingiById(int id);
        Task AddParking(Parking parking);
        Task DeleteParking(Parking parking);
        Task UpdateParking(Parking parking);
    }
}
