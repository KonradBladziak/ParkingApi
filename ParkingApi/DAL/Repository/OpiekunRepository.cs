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
    public class OpiekunRepository : Repository<Opiekun>, IOpiekunRepository
    {
        public OpiekunRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<Opiekun>> GetAllAsync()
        {
            return await FindAll().OrderBy(x => x.Nazwisko).ToListAsync();
        }

        public async Task<Opiekun> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Add(Opiekun opiekun)
        {
            Add(opiekun);
        }

        public async Task Delete(Opiekun opiekun)
        {
            Delete(opiekun);
        }

        public async Task Update(Opiekun opiekun)
        {
            Update(opiekun);
        }


    }
}
