using BLL.DTO;
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

        public async Task<IEnumerable<MiejsceResponse>> GetMiejscaResponse(int parkingId, DateTime od, DateTime @do)
        {
            // jako tako działa
            //return (from miejsce in await unitOfWork.MiejsceRepository.GetAllAsync()
            //              where miejsce.ParkingId == parkingId
            //              join miejsceInwalidzkie in await unitOfWork.MiejsceInwalidzkieRepository.GetAllAsync()
            //                  on miejsce.MiejsceInwalidzkieId equals miejsceInwalidzkie.Id into miejsceInwalidzkieGroup
            //              from miejsceInwalidzkie in miejsceInwalidzkieGroup.DefaultIfEmpty()
            //              select new MiejsceResponse
            //              {
            //                  Id = miejsce.Id,
            //                  MiejsceInwalidzkieId = miejsceInwalidzkie != null ? miejsceInwalidzkie.Id : null,
            //                  RozmiarMiejscaInwalidzkiego = miejsceInwalidzkie != null ? miejsceInwalidzkie.RozmiarMiejsca : 0
            //              });

            // jako tako mniej działa
            //return (from miejsce in await unitOfWork.MiejsceRepository.GetAllAsync()
            //         where miejsce.ParkingId == parkingId &&
            //               (miejsce.Rezerwacje == null || !miejsce.Rezerwacje.Any(r => (r.Od >= od && r.Od <= @do) || (r.Do >= od && r.Do <= @do)))
            //         join miejsceInwalidzkie in await unitOfWork.MiejsceInwalidzkieRepository.GetAllAsync()
            //             on miejsce.MiejsceInwalidzkieId equals miejsceInwalidzkie.Id into miejsceInwalidzkieGroup
            //         from miejsceInwalidzkie in miejsceInwalidzkieGroup.DefaultIfEmpty()
            //         select new MiejsceResponse
            //         {
            //             Id = miejsce.Id,
            //             MiejsceInwalidzkieId = miejsceInwalidzkie != null ? miejsceInwalidzkie.Id : 0,
            //             RozmiarMiejscaInwalidzkiego = miejsceInwalidzkie != null ? miejsceInwalidzkie.RozmiarMiejsca : 0
            //         });

            var wolneMiejsca = (from miejsce in await unitOfWork.MiejsceRepository.GetAllAsync()
                                      where miejsce.ParkingId == parkingId
                                      join miejsceInwalidzkie in await unitOfWork.MiejsceInwalidzkieRepository.GetAllAsync()
                                          on miejsce.MiejsceInwalidzkieId equals miejsceInwalidzkie.Id into miejsceInwalidzkieGroup
                                      from miejsceInwalidzkie in miejsceInwalidzkieGroup.DefaultIfEmpty()
                                      select new
                                      {
                                          Miejsce = miejsce,
                                          MiejsceInwalidzkie = miejsceInwalidzkie
                                      }).ToList();

            var wolneMiejscaResponse = wolneMiejsca
                .Where(item => item.Miejsce.Rezerwacje == null || !item.Miejsce.Rezerwacje.Any(r => (r.Od >= od && r.Od <= @do) || (r.Do >= od && r.Do <= @do)))
                .Select(item => new MiejsceResponse
                {
                    Id = item.Miejsce.Id,
                    MiejsceInwalidzkieId = item.MiejsceInwalidzkie != null ? item.MiejsceInwalidzkie.Id : 0,
                    RozmiarMiejscaInwalidzkiego = item.MiejsceInwalidzkie != null ? item.MiejsceInwalidzkie.RozmiarMiejsca : 0
                })
                .ToList();

            return wolneMiejscaResponse;
        }
    }
}
