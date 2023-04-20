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
        public async Task <IEnumerable<Rezerwacja>> GetRezerwacje()
        {
            return await _context.Rezerwacje.ToListAsync();
        }
        public async Task <Rezerwacja> GetRezerwacjaById(int id)
        {
            return await _context.Rezerwacje.FindAsync(id);
        }
        public async Task UpdateRezerwacja(Rezerwacja rezerwacja)
        {
            _context.Entry(rezerwacja).State = EntityState.Modified;
            await Save();
        }
        public async Task InsertRezerwacja(Rezerwacja rezerwacja)
        {
            await _context.Rezerwacje.AddAsync(rezerwacja);
        }
        public async Task DeleteRezerwacja(int id)
        {
            Rezerwacja rezerwacja = await _context.Rezerwacje.FindAsync(id);
            _context.Rezerwacje.Remove(rezerwacja);
            await Save();
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
        public async Task Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
