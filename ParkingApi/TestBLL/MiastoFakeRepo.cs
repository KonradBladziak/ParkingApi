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
    public class MiastoFakeRepo : IMiastoRepository
    { 
        private List<Miasto> miasta = new List<Miasto>();

        public void Add(Miasto miasto)
        {
            miasta.Add(miasto);
            return;
        }

        public void Delete(Miasto miasto)
        {
            var _miasto = miasta.Find(m => m.Id == miasto.Id);
            miasta.Remove(_miasto);
            return;
        }

        public IQueryable<Miasto> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Miasto> FindByCondition(Expression<Func<Miasto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Miasto>> GetAllAsync()
        {
            var _miasta = Task.FromResult(miasta).Result.ToList();
            return _miasta;
        }

        public Task<Miasto> GetByIdAsync(int id)
        {
            var miasto = Task.FromResult(miasta.Find(m => m.Id == id));
            return miasto;
        }

        public async Task<Miasto> GetByIdAsyncDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async void Update(Miasto miasto)
        {
            var indexMiasta = await Task.FromResult(miasta.FindIndex(p => p.Id == miasto.Id));
            if (indexMiasta > 0)
            {
                miasta[indexMiasta] = miasto;
            }
            return;
        }
    }
}
