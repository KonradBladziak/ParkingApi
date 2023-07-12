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
    public class MiastoService : IMiastoService
    {
        private IUnitOfWork unitOfWork;

        public MiastoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }   

        public async Task <List<Miasto>> GetMiasta()
        {
            var res = unitOfWork.MiastoRepository.GetAllAsync().Result;

            return res.ToList();
        }

        public async Task<Miasto> GetMiastoById(int id)
        {
            return unitOfWork.MiastoRepository.GetByIdAsync(id).Result;
        }

        public async Task AddMiasto(Miasto miasto)
        {
            unitOfWork.MiastoRepository.Add(miasto);

            await unitOfWork.SaveAsync();
        }

        public async Task DeleteMiasto(Miasto miasto)
        {
            unitOfWork.MiastoRepository.Delete(miasto);

            await unitOfWork.SaveAsync();
        }

        public async Task UpdateMiasto(Miasto miasto)
        { 
            unitOfWork.MiastoRepository.Update(miasto);

            await unitOfWork.SaveAsync();
        }
    }
}
