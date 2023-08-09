using BLL.DTO;
using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        public async Task <IEnumerable<Miasto>> GetMiasta()
        {
            var res = await unitOfWork.MiastoRepository.GetAllAsync();

            return res;
        }

        public async Task<Miasto> GetMiastoById(int id)
        {
            return await unitOfWork.MiastoRepository.GetByIdAsync(id);
        }

        public async Task<Miasto> GetMiastoByIdDetails(int id)
        {
            return await unitOfWork.MiastoRepository.GetByIdAsyncDetails(id);
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

        public async Task<List<MiastoResponse>> GetMiastaResponse() 
        {
            var miasta = await unitOfWork.MiastoRepository.GetAllAsync();

            return (from miasto in miasta.ToList()
                    select new MiastoResponse
                    {
                        Id = miasto.Id,
                        Nazwa = miasto.Nazwa,
                        Wojewodztwo = miasto.Wojewodztwo
                    }).ToList();
        }
        
    }
}
