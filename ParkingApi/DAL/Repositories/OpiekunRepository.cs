using DAL.DataContext;
using DAL.Entity;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OpiekunRepository : IOpiekunRepository, IDisposable
    {
        private readonly DatabaseContext _context;

        public OpiekunRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ICollection<Opiekun> GetOpiekunowie()
        {
            return _context.Opiekunowie.ToList();
        }

        public ICollection<Parking> GetParkingi(int id)
        {
            return _context.Opiekunowie.Find(id).Parkingi;
        }

        public Opiekun GetOpiekunById(int id)
        {
            return _context.Opiekunowie.Find(id);
        }

        public void InsertOpiekun(Opiekun opiekun)
        {
            _context.Opiekunowie.Add(opiekun);
        }

        public void DeleteOpiekun(int id)
        {
            Opiekun opiekun = _context.Opiekunowie.Find(id);
            _context.Opiekunowie.Remove(opiekun);
        }

        public void UpdateOpiekun(Opiekun opiekun)
        {
            _context.Entry(opiekun).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
