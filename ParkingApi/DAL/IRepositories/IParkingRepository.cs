using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IParkingRepository : IDisposable
    {
        ICollection<Parking> GetParkingi();
        ICollection<Opiekun> GetOpiekunowie(int id);
        ICollection<Miejsce> GetMiejsca(int id);
        Parking GetParkingById(int id);
        Miasto GetMiasto(int id);
        void InsertParking(Parking parking);
        void DeleteParking(int id);
        void UpdateParking(Parking parking);
        void Save();
    }
}
