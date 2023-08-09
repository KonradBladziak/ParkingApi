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
    public class MiejsceInwalidzkieRepository : Repository<MiejsceInwalidzkie>, IMiejsceInwalidzkieRepository
    {
        public MiejsceInwalidzkieRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<MiejsceInwalidzkie>> GetAllAsync()
        {
            return await FindAll().Include(x => x.Miejsce).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<MiejsceInwalidzkie> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<MiejsceInwalidzkie?> GetByIdAsyncDetails(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.Miejsce).FirstOrDefaultAsync();
        }


        public async Task Add(MiejsceInwalidzkie miejsce)
        {
            Add(miejsce);
        }

        public async Task Delete(MiejsceInwalidzkie miejsce)
        {
            Delete(miejsce);
        }

        public async Task Update(MiejsceInwalidzkie miejsce)
        {
            Update(miejsce);
        }


    }
}
