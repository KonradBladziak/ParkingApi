using Abp.Timing;
using BLL.DTO;
using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkServices
{
    public class RezerwacjaService : IRezerwacjeService
    {
        private IUnitOfWork unitOfWork;

        public RezerwacjaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Rezerwacja>> GetRezerwacje()
        {
            var res = await unitOfWork.RezerwacjaRepository.GetAllAsync();

            return res;
        }

        public async Task<Rezerwacja> GetRezerwacjaById(int id)
        {
            return await unitOfWork.RezerwacjaRepository.GetByIdAsync(id);
        }

        public async Task<Rezerwacja> GetRezerwacjaByIdDetails(int id)
        {
            return await unitOfWork.RezerwacjaRepository.GetByIdAsyncDetails(id);
        }

        public async Task AddRezerwacja(Rezerwacja rezerwacja)
        {
            unitOfWork.RezerwacjaRepository.Add(rezerwacja);

            await unitOfWork.SaveAsync();
        }

        public async Task DeleteRezerwacja(Rezerwacja rezerwacja)
        {
            unitOfWork.RezerwacjaRepository.Delete(rezerwacja);

            await unitOfWork.SaveAsync();
        }

        public async Task UpdateRezerwacja(Rezerwacja rezerwacja)
        {
            unitOfWork.RezerwacjaRepository.Update(rezerwacja);

            await unitOfWork.SaveAsync();
        }

        public async Task<bool> CzyMoznaRezerwowac(int idMiejsca, DateTime Od, DateTime Do,int? idRezerwacji = null)
        {
            List<Rezerwacja?> rezerwacje = await unitOfWork.RezerwacjaRepository.GetRezerwacjeByIdMiejsca(idMiejsca);

            if (idRezerwacji != null) 
            {
                rezerwacje.Remove(rezerwacje.Find(x => x.Id == idRezerwacji));
            }

            if (rezerwacje.Count() > 0)
            {
                DateTimeRange nowaRezerwacja = new DateTimeRange(Od, Do);
                foreach (var item in rezerwacje)
                {
                    DateTimeRange innaRezerwacja = new DateTimeRange(item.Od, item.Do);

                    if (nowaRezerwacja.StartTime < innaRezerwacja.EndTime && innaRezerwacja.StartTime <= nowaRezerwacja.EndTime)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        
    }
}
