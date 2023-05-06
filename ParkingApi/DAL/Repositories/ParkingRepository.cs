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
    public class ParkingRepository : IParkingRepository, IDisposable
    {
        private readonly DatabaseContext _context;

        public ParkingRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Parking> GetParkingById(int? id)
        {
            return await _context.Parkingi
                .Include(p => p.Miasto)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Parking>> GetParkingi()
        {
            return await _context.Parkingi.
            Include(p => p.Miasto).
            ToListAsync();

        }

        public async Task InsertParking(Parking parking)
        {
            _context.Add(parking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParking(Parking parking)
        {
            _context.Update(parking);
            await Save();
        }

        public async Task DeleteParking(Parking parking)
        {
            _context.Parkingi.Remove(parking);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
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
