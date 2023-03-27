using DAL.DataContext;
using DAL.Entity;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MiastoRepository : IMiastoRepository, IDisposable
    {

        private DatabaseContext _context;

        public MiastoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task <ICollection<Parking>> GetParkingi(int id)
        {
            return _context.Miasta.Find(id).Parkingi;
        }

        public async Task<IEnumerable<Miasto>> GetMiasta()
        {
            return await _context.Miasta.ToListAsync();
        }
        public async Task DeleteMiasto(int? id)
        {
            var miasto = await _context.Miasta.FindAsync(id);
            _context.Miasta.Remove(miasto);
        }

        public async Task <Miasto> GetMiastoById(int? id)
        {
            return await _context.Miasta.FindAsync(id);
        }

        public async Task InsertMiasto(Miasto miasto)
        {
            await _context.Miasta.AddAsync(miasto);
        }

        public async Task UpdateMiasto(Miasto miasto)
        {
            _context.Entry(miasto).State = EntityState.Modified;
        }

        public async Task Save()
        {
            _context.SaveChangesAsync();
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
