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
        public async Task <ICollection<Miejsce>> GetMiejsca()
        {
            return await _context.Miejsca
                .Include(m => m.Parking)
                .ToListAsync();
        }
        public async Task <ICollection<Rezerwacja>> GetRezerwacje()
        {
            return await _context.Rezerwacje
                .Include(m => m.Miejsce)
                .ToListAsync();
        }

        public async Task <Miejsce> GetMiejscaById(int? id)
        {
            return await _context.Miejsca
                .Include(m => m.Parking)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task InsertMiejsce(Miejsce miejsce)
        {
            _context.Miejsca.Add(miejsce);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMiejsce(Miejsce miejsce)
        {
            _context.Remove(miejsce);
            await Save();
        }
        public async Task UpdateMiejsce(Miejsce miejsce)
        {
            _context.Update(miejsce);
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
