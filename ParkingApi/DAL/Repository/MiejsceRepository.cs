using DAL.DataContext;
using DAL.Entity;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MiejsceRepository : Repository<Miejsce>, IMiejsceRepository
    {
        public MiejsceRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<Miejsce>> GetAllAsync()
        {
            return await FindAll().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Miejsce> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Miejsce?> GetByIdAsyncDetails(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).Include(x=> x.Parking).Include(x=>x.MiejsceInwalidzkie).FirstOrDefaultAsync();
        }

        public async Task Add(Miejsce miasto)
        {
            Add(miasto);
        }

        public async Task Delete(Miejsce miasto)
        {
            Delete(miasto);
        }

        public async Task Update(Miejsce miasto)
        {
            Update(miasto);
        }


    }
}
