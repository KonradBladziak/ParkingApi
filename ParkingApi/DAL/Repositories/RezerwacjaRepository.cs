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
    public class RezerwacjaRepository : IRezerwacjaRepository, IDisposable
    {
        private DatabaseContext _context;
        private bool disposed = false;
        public RezerwacjaRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public ICollection<Rezerwacja> GetRezerwacje()
        {
            return _context.Rezerwacje.ToList();
        }
        public Rezerwacja GetRezerwacjaById(int id)
        {
            return _context.Rezerwacje.Find(id);
        }
        public void UpdateRezerwacja(Rezerwacja rezerwacja)
        {
            _context.Entry(rezerwacja).State = EntityState.Modified;
        }
        public void AddRezerwacja(Rezerwacja rezerwacja)
        {
            _context.Rezerwacje.Add(rezerwacja);
        }
        public void DeleteRezerwacja(int id)
        {
            Rezerwacja rezerwacja = _context.Rezerwacje.Find(id);
            _context.Remove(rezerwacja);
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
