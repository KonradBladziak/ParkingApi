using DAL.DataContext;
using DAL.Entity;
using DAL.IRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MiastoRepository : Repository<Miasto>, IMiastoRepository
    {
        public MiastoRepository(DatabaseContext databaseContext):base(databaseContext) { }

        public async Task<IEnumerable<Miasto>> GetAllAsync()
        {
            return await FindAll().OrderBy(x => x.Nazwa).ToListAsync(); 
        }

        public async Task<Miasto> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Miasto miasto)
        {
            Add(miasto);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Miasto miasto)
        {
            Delete(miasto);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Miasto miasto)
        {
            Update(miasto);
            await databaseContext.SaveChangesAsync();
        }
        

    }
}
