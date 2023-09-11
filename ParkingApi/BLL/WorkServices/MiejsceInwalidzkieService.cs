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
    public class MiejsceInwalidzkieService : IMiejscaInwalidzkieService
    {
        private IUnitOfWork unitOfWork;

        public MiejsceInwalidzkieService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<MiejsceInwalidzkie>> GetMiejscaInwalidzkie()
        {
            var res = await unitOfWork.MiejsceInwalidzkieRepository.GetAllAsync();

            return res.ToList();
        }

        public async Task<MiejsceInwalidzkie> GetMiejsceInwalidzkieById(int id)
        {
            return await unitOfWork.MiejsceInwalidzkieRepository.GetByIdAsync(id);
        }

        public async Task<MiejsceInwalidzkie> GetMiejsceInwalidzkieByIdDetails(int id)
        {
            return await unitOfWork.MiejsceInwalidzkieRepository.GetByIdAsyncDetails(id);
        }

        public async Task<bool> CzyToMiejsceInwalidzkie(int idMiejsca) 
        {
            if (await unitOfWork.MiejsceInwalidzkieRepository.GetByIdMiejsca(idMiejsca) != null) 
            { 
                return true;
            }

            return false;
        }

        public async Task AddMiejsceInwalidzkie(MiejsceInwalidzkie miejsce)
        {
            unitOfWork.MiejsceInwalidzkieRepository.Add(miejsce);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteMiejsceInwalidzkie(MiejsceInwalidzkie miejsce)
        {
            unitOfWork.MiejsceInwalidzkieRepository.Delete(miejsce);
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateMiejsceInwalidzkie(MiejsceInwalidzkie miejsce)
        {
            unitOfWork.MiejsceInwalidzkieRepository.Update(miejsce);
            await unitOfWork.SaveAsync();
        }
    }
}
