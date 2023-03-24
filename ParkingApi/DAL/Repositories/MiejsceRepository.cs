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
    public class MiejsceRepository : IMiejsceRepository, IDisposable
    {
        private DatabaseContext _context;
        private bool disposed = false;
        public MiejsceRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public ICollection<Miejsce> GetMiejsca()
        {
            return _context.Miejsca.ToList();
        }
        public ICollection<Rezerwacja> GetRezerwacje()
        {
            return _context.Rezerwacje.ToList();
        }

        public Miejsce GetMiejscaById(int id)
        {
            return _context.Miejsca.Find(id);
        }
        public void AddMiejsce(Miejsce miejsce)
        {
            _context.Miejsca.Add(miejsce);
        }

        public void DeleteMiejsce(int id)
        {
            Miejsce miejsce = _context.Miejsca.Find(id);
            _context.Remove(miejsce);
        }
        public void UpdateMiejsce(Miejsce miejsce)
        {
            _context.Entry(miejsce).State = EntityState.Modified;
        }
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
