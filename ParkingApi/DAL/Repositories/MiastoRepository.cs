using DAL.DataContext;
using DAL.Entity;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MiastoRepository : IMiastoRepository, IDisposable
    {

        private readonly DatabaseContext _context;

        public MiastoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ICollection<Parking> GetParkingi(int id)
        {
            return _context.Miasta.Find(id).Parkingi;
        }

        public ICollection<Miasto> GetMiasta()
        {
            return _context.Miasta.ToList();
        }
        public void DeleteMiasto(int id)
        {
            Miasto miasto = _context.Miasta.Find(id);
            _context.Miasta.Remove(miasto);
        }

        public Miasto GetMiastoById(int id)
        {
            return _context.Miasta.Find(id);
        }

        public void InsertMiasto(Miasto miasto)
        {
            _context.Miasta.Add(miasto);
        }

        public void UpdateMiasto(Miasto miasto)
        {
            _context.Entry(miasto).State = EntityState.Modified;
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
