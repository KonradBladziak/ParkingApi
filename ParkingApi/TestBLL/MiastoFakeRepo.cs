using DAL.DataContext;
using DAL.Entity;
using DAL.IRepository;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class MiastoFakeRepo : Repository<Miasto>, IMiastoRepository
    { 
        private List<Miasto> miasta = new List<Miasto>();

        public MiastoFakeRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task Add(Miasto miasto)
        {
            miasta.Add(miasto);
            return;
        }

        public async Task Delete(Miasto miasto)
        {
            var _miasto = await Task.FromResult(miasta.Find(m => m.Id == miasto.Id));
            miasta.Remove(_miasto);
            return;
        }

        public async Task<IEnumerable<Miasto>> GetAllAsync()
        {
            var _miasta = await Task.FromResult(miasta);
            return _miasta;
        }

        public async Task<Miasto> GetByIdAsync(int id)
        {
            var miasto = await Task.FromResult(miasta.Find(m => m.Id == id));
            return miasto;
        }

        public async Task Update(Miasto miasto)
        {
            var indexMiasta = await Task.FromResult(miasta.FindIndex(p => p.Id == miasto.Id));
            if (indexMiasta > 0)
            {
                miasta[indexMiasta] = miasto;
            }
            return;
        }

        public async Task<Miasto> GetByIdAsyncDetails(int id)
        {
           var miasto = await Task.FromResult(FindByCondition(m => m.Id == id).Include(m => m.Parkingi));
           return (Miasto)miasto;
        }
    }
}
