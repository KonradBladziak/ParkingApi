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

        public ICollection<MiejsceInwalidzkie> GetMiejscaInwalidzkie()
        {
            return _context.MiesjcaInwalidzkie.ToList();
        }
        public ICollection<Miejsce> GetMiejsca()
        {
            return _context.Miejsca.ToList();
        }
        public Miejsce GetMiejsceById(int id)
        {
            return _context.Miejsca.Find(id);
        }

        public MiejsceInwalidzkie GetMiejsceInwalidzkieById(int id)
        {
            return _context.MiesjcaInwalidzkie.Find(id);
        }

        public void UpdateMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie)
        {
            _context.Entry(miejsceInwalidzkie).State = EntityState.Modified;
        }
        public void AddMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie)
        {
            _context.MiesjcaInwalidzkie.Add(miejsceInwalidzkie);
        }

        public void DeleteMiejsceInwalidzkie(int id)
        {
             MiejsceInwalidzkie miejsceInwalidzkie= _context.MiesjcaInwalidzkie.Find(id);
            _context.Remove(miejsceInwalidzkie);
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
