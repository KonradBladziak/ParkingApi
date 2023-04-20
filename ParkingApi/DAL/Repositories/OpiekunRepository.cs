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

        public async Task <IEnumerable<Opiekun>> GetOpiekunowie()
        {
            return await _context.Opiekunowie.ToListAsync();
        }

        public async Task <ICollection<Parking>> GetParkingi(int id)
        {
            return _context.Opiekunowie.Find(id).Parkingi;
        }

        public async Task <Opiekun> GetOpiekunById(int id)
        {
            return await _context.Opiekunowie.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task InsertOpiekun(Opiekun opiekun)
        {
            await _context.Opiekunowie.AddAsync(opiekun);
            await Save();
        }

        public async Task DeleteOpiekun(int id)
        {
            Opiekun opiekun = await _context.Opiekunowie.FindAsync(id);
            _context.Opiekunowie.Remove(opiekun);
            await Save();
        }

        public async Task UpdateOpiekun(Opiekun opiekun)
        {
            _context.Entry(opiekun).State = EntityState.Modified;
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
