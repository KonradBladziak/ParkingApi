using BLL.DTO;
using BLL.IWorkServices;
using Castle.Windsor.Installer;
using DAL.Entity;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkServices
{
    public class MiejsceService : IMiejsceService
    {
        private IUnitOfWork unitOfWork;
        public MiejsceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Miejsce>> GetMiejsca()
        {
            var res = await unitOfWork.MiejsceRepository.GetAllAsync();
            return res;
        }

        public async Task<Miejsce> GetMiejsceById(int id)
        {
            return await unitOfWork.MiejsceRepository.GetByIdAsync(id);
        }

        public async Task<Miejsce> GetMiejsceByIdDetails(int id)
        {
            return await unitOfWork.MiejsceRepository.GetByIdAsyncDetails(id);
        }

        public async Task AddMiejsce(Miejsce miejsce)
        {
            unitOfWork.MiejsceRepository.Add(miejsce);

            await unitOfWork.SaveAsync();
        }

        public async Task DeleteMiejsce(Miejsce miejsce)
        {
            unitOfWork.MiejsceRepository.Delete(miejsce);

            await unitOfWork.SaveAsync();
        }

        public async Task UpdateMiejsce(Miejsce miejsce)
        {
            unitOfWork.MiejsceRepository.Update(miejsce);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MiejsceResponse>> GetMiejscaResponse(int parkingId, DateTime Od, DateTime Do)
        {

            var miejsca = await unitOfWork.MiejsceRepository.GetAllAsync();
            var rezerwacje = await unitOfWork.RezerwacjaRepository.GetRezerwacjeInTimeRange(parkingId, Od, Do);

            return (from miejsce in await unitOfWork.MiejsceRepository.GetAllAsync()
                    where miejsce.ParkingId == parkingId
                    join miejsceInwalidzkie in await unitOfWork.MiejsceInwalidzkieRepository.GetAllAsync()
                        on miejsce.MiejsceInwalidzkieId equals miejsceInwalidzkie.Id into miejsceInwalidzkieGroup
                    from miejsceInwalidzkie in miejsceInwalidzkieGroup.DefaultIfEmpty()
                    select new MiejsceResponse
                    {
                        IdMiejsca = miejsce.Id,
                        IdMiejscaInwalidzkiego = miejsceInwalidzkie != null ? miejsceInwalidzkie.Id : null,
                        RozmiarMiejscaInwalidzkiego = miejsceInwalidzkie != null ? miejsceInwalidzkie.RozmiarMiejsca : 0,
                        CzyDostepne = !rezerwacje.Any(r => r.IdMiejsca == miejsce.Id && (r.Od <= Od && r.Do >= Do))
                    });
        }
    }
}


