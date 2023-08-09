using BLL.DTO;
using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.CodeAnalysis.Operations;
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
            return await unitOfWork.ParkingRepository.GetByIdAsync(id);
        }

        public async Task<Parking> GetParkingiByIdDetails(int id)
        {
            return await unitOfWork.ParkingRepository.GetByIdDetailsAsync(id);
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

        public async Task AddParking(string nazwaParkingu, string adres, int idMiasta, int idOpiekuna)
        {
            var miasto = await unitOfWork.MiastoRepository.GetByIdAsync(idMiasta);
            //var opiekun = await unitOfWork.OpiekunRepository.GetByIdAsync(idOpiekuna);
            Parking parking = new Parking
            {
                Nazwa = nazwaParkingu,
                Adres = adres,
                IdMiasta = idMiasta
            };

            //parking.Opiekunowie.Add(opiekun);

            unitOfWork.ParkingRepository.Add(parking);

            await unitOfWork.SaveAsync();
        }

        public async Task UpdateParking(Parking parking)
        {
            unitOfWork.ParkingRepository.Update(parking);

            await unitOfWork.SaveAsync();
        }

        public async Task<Parking> AddOpiekun(int idParkingu,int idOpiekuna)
        {
            var parking = await GetParkingiById(idParkingu);
            var opiekun = await unitOfWork.OpiekunRepository.GetByIdAsync(idOpiekuna);

            parking.Opiekunowie.Add(opiekun);

            unitOfWork.ParkingRepository.Update(parking);

            await unitOfWork.SaveAsync();

            return await GetParkingiByIdDetails(idParkingu);
        }

        public async Task<ICollection<Miejsce>> AddMiejsca(int idParkingu, int count)
        {
            var parking = await GetParkingiById(idParkingu);

            for (int i = 0; i < count; i++)
            {
                var noweMiejsce = new Miejsce
                {
                    ParkingId = idParkingu,
                };

                unitOfWork.MiejsceRepository.Add(noweMiejsce);
            }

            unitOfWork.ParkingRepository.Update(parking);
            await unitOfWork.SaveAsync();

            return GetParkingiById(idParkingu).Result.Miejsca;

        }

        public async Task Save()
        {
            await unitOfWork.SaveAsync();
        }

        public async Task<ICollection<Opiekun>> UsunOpiekuna(int idOpiekuna, int idParkingu)
        {
            await unitOfWork.ParkingRepository.UsunOpiekuna(idParkingu, idOpiekuna);

            return GetParkingiById(idParkingu).Result.Opiekunowie;
        }

        public async Task<IEnumerable<ParkingResponse>> GetParkingiResponse(int miastoId)
        {
            return (from parking in await unitOfWork.ParkingRepository.GetAllAsync()
                    where parking.IdMiasta == miastoId
                    select new ParkingResponse
                    {
                        Id = parking.Id,
                        Nazwa = parking.Nazwa,
                        Adres = parking.Adres
                    });
        }
    }
}
