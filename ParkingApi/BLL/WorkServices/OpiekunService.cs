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
    public class OpiekunService : IOpiekunService
    {
        private IUnitOfWork unitOfWork;

        public OpiekunService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Opiekun>> GetOpiekunowie()
        {
            var res = await unitOfWork.OpiekunRepository.GetAllAsync();

            return res;
        }

        public async Task<Opiekun> GetOpiekunById(int id)
        {
            return await unitOfWork.OpiekunRepository.GetByIdAsync(id);
        }

        public async Task AddOpiekun(Opiekun opiekun)
        {
            unitOfWork.OpiekunRepository.Add(opiekun);

            await unitOfWork.SaveAsync();
        }

        public async Task DeleteOpiekun(Opiekun opiekun)
        {
            unitOfWork.OpiekunRepository.Delete(opiekun);

            await unitOfWork.SaveAsync();
        }

        public async Task UpdateOpiekun(Opiekun opiekun)
        {
            unitOfWork.OpiekunRepository.Update(opiekun);

            await unitOfWork.SaveAsync();
        }
    }
}
