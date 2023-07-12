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
    public class ParkingRepository : Repository<Parking>, IParkingRepository
    {
        public ParkingRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<Parking>> GetAllAsync()
        {
            return await FindAll().OrderBy(x => x.Nazwa).ToListAsync();
        }

        public async Task<Parking> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Add(Parking parking)
        {
            Add(parking);
        }

        public async Task Delete(Parking parking)
        {
            Delete(parking);
        }

        public async Task Update(Parking parking)
        {
            Update(parking);
        }
    }

}