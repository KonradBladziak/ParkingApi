using DAL.DataContext;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DatabaseContext databaseContext { get; set; }

        public Repository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.databaseContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.databaseContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public void Add(T entity)
        {
            this.databaseContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.databaseContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.databaseContext.Set<T>().Remove(entity);
        }
    }
}
