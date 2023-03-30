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
    public class InwalidzkieRepository : IInwalidzkieRepository, IDisposable
    {
        private DatabaseContext _context;
        private bool disposed = false;
        public InwalidzkieRepository(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<MiejsceInwalidzkie>> GetMiejscaInwalidzkie()
        {
            return await _context.MiesjcaInwalidzkie
                .Include(m => m.Miejsce)
                .ToListAsync();
        }
        public async Task<ICollection<Miejsce>> GetMiejsca()
        {
            return await _context.Miejsca
                 .Include(m => m.Parking)
                 .ToListAsync();
        }
        public async Task<Miejsce> GetMiejsceById(int? id)
        {
            return await _context.Miejsca
                .Include(m => m.Parking)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MiejsceInwalidzkie> GetMiejsceInwalidzkieById(int? id)
        {
            return await _context.MiesjcaInwalidzkie
                .Include(m => m.Miejsce)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie)
        {
            _context.Update(miejsceInwalidzkie);
            await Save();
        }
        public async Task InsertMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie)
        {
            _context.Add(miejsceInwalidzkie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie)
        {
            _context.Remove(miejsceInwalidzkie);
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
