﻿using BLL.IWorkServices;
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
    }
}
