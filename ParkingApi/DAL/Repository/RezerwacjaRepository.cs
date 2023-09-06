using DAL.DataContext;
using Abp.Timing;
using DAL.Entity;
using DAL.IRepository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RezerwacjaRepository : Repository<Rezerwacja>, IRezerwacjaRepository
    {
        public RezerwacjaRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<Rezerwacja>> GetAllAsync()
        {
            return await FindAll().Include(x => x.Miejsce).ThenInclude(x => x.Parking).OrderBy(x => x.Nazwisko).ToListAsync();
        }

        public async Task<Rezerwacja> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Rezerwacja?> GetByIdAsyncDetails(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.Miejsce).ThenInclude(x => x.Parking).FirstOrDefaultAsync();
        }

        public async Task<List<Rezerwacja?>> GetRezerwacjeByIdMiejsca(int id) 
        {
            return await FindByCondition(x => x.IdMiejsca.Equals(id)).ToListAsync();
        } 

        public async Task Add(Rezerwacja rezerwacja)
        {
            Add(rezerwacja);
        }

        public async Task Delete(Rezerwacja rezerwacja)
        {
            Delete(rezerwacja);
        }

        public async Task Update(Rezerwacja rezerwacja)
        {
            Update(rezerwacja);
        }

        public async Task<bool> CzyMoznaRezerwowac(int idMiejsca, DateTime Od, DateTime Do, int? idRezerwacji = null)
        {
            List<Rezerwacja?> rezerwacje = await GetRezerwacjeByIdMiejsca(idMiejsca);

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
