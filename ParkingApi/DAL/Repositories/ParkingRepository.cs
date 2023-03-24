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

        public ICollection<Parking> GetParkingi()
        {
            return _context.Parkingi.ToList();
        }

        public ICollection<Opiekun> GetOpiekunowie(int id)
        {
            return _context.Parkingi.Find(id).Opiekunowie.ToList();
        }

        public ICollection<Miejsce> GetMiejsca(int id)
        {
            return _context.Parkingi.Find(id).Miejsca.ToList();
        }

        public Miasto GetMiasto(int id)
        {
            return _context.Parkingi.Find(id).Miasto;
        }

        public Parking GetParkingById(int id)
        {
            return _context.Parkingi.Find(id);
        }

        public void InsertParking(Parking parking)
        {
            _context.Parkingi.Add(parking);
        }

        public void DeleteParking(int id)
        {
            Parking parking = _context.Parkingi.Find(id);
            _context.Parkingi.Remove(parking);
        }
        
        public void UpdateParking(Parking parking)
        {
            _context.Entry(parking).State = EntityState.Modified;
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
