using DAL.Entity;
using DAL.IRepositories;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    internal class ParkingRespositoryFake : IParkingRepository
    {
        private List<Parking> parkingi = new List<Parking>();

        public async Task DeleteParking(Parking parking)
        {
            var res = parkingi.Find(x => x.Id == parking.Id);
            parkingi.Remove(res);
        }

        public async Task<IEnumerable<Parking>> GetParkingi()
        {
            return await Task.FromResult<IEnumerable<Parking>>(parkingi);
        }

        public async Task<Parking> GetParkingById(int? id)
        {
            return await Task.FromResult<Parking>(parkingi.Find(x => x.Id == id));
        }
        
        public async Task InsertParking(Parking parking)
        {
            parkingi.Add(parking);
        }

        public async Task UpdateParking(Parking parking)
        {
            int index = this.parkingi.FindIndex(x => x.Id == parking.Id);
            if (index != -1)
                parkingi[index] = parking;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
