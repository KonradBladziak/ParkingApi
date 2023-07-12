using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkServices
{
    public class ParkingService : IParkingService
    {
        private IUnitOfWork unitOfWork;

        public ParkingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Parking>> GetParkingi()
        {
            var res = await unitOfWork.ParkingRepository.GetAllAsync();

            return res.ToList();
        }

        public async Task<Parking> GetParkingiById(int id)
        {
            return unitOfWork.ParkingRepository.GetByIdAsync(id).Result;
        }

        public async Task AddParking(Parking parking)
        {
            unitOfWork.ParkingRepository.Add(parking);

            await unitOfWork.SaveAsync();
        }

        public async Task DeleteParking(Parking parking)
        {
            unitOfWork.ParkingRepository.Delete(parking);

            await unitOfWork.SaveAsync();
        }

        public async Task UpdateParking(Parking parking)
        {
            unitOfWork.ParkingRepository.Update(parking);

            await unitOfWork.SaveAsync();
        }
    }
}
