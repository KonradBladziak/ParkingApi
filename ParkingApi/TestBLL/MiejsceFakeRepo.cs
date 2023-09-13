using DAL.Entity;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class MiejsceFakeRepo : IMiejsceRepository
    {
        private List<Miejsce> miejsca = new List<Miejsce>();

        public void Add(Miejsce miejsce)
        {
            miejsca.Add(miejsce);
            return;
        }

        public void Delete(Miejsce miejsce)
        {
            var _miejsce = miejsca.Find(m => m.Id == miejsce.Id);
            miejsca.Remove(_miejsce);
            return;
        }

        public IQueryable<Miejsce> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Miejsce> FindByCondition(Expression<Func<Miejsce, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Miejsce>> GetAllAsync()
        {
            var _miejsca = Task.FromResult(miejsca).Result.ToList();
            return _miejsca;
        }

        public Task<Miejsce> GetByIdAsync(int id)
        {
            var miejsce = Task.FromResult(miejsca.Find(m => m.Id == id));
            return miejsce;
        }

        public Task<Miejsce> GetByIdAsyncDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Miejsce>> GetByParkingIdAsync(int idParkingu)
        {
            throw new NotImplementedException();
        }

        public async void Update(Miejsce miejsce)
        {
            var indexMiejsca = await Task.FromResult(miejsca.FindIndex(p => p.Id == miejsce.Id));
            if (indexMiejsca > 0)
            {
                miejsca[indexMiejsca] = miejsce;
            }
            return; ;
        }
    }
}
