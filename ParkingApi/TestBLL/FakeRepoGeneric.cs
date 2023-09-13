using DAL.DataContext;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class FakeRepoGeneric<T> : IRepository<T> where T : class
    {
        protected IQueryable<T> databaseContext { get; set; }

        public FakeRepoGeneric(IQueryable<T> databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.databaseContext.AsQueryable<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.databaseContext.Where<T>(expression).AsNoTracking();
        }
        public void Add(T entity)
        {
            this.databaseContext.Append<T>(entity);
        }
        public void Update(T entity)
        {
            var lista = databaseContext.ToList<T>();

            var obiektAktualizowany = lista.FirstOrDefault<T>(entity);

            databaseContext = lista.AsQueryable<T>();
        }
        public void Delete(T entity)
        {
            var lista = databaseContext.ToList<T>();

            lista.Remove(entity);

            databaseContext = lista.AsQueryable<T>();
        }
    }
}