using DAL.DataContext;
using DAL.IRepositories;
using DAL.Repositories;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    public class TestUnitOfWork : IUnitOfWork
    {

        private DatabaseContext _context;
        private IMiastoRepository miastoRepository;
        private IMiejsceRepository miejsceRepository;
        private IInwalidzkieRepository inwalidzkieRepository;
        private IParkingRepository parkingRepository;
        private IOpiekunRepository opiekunRepository;
        private IRezerwacjaRepository rezerwacjaRepository;
        private bool disposed = false;

        public TestUnitOfWork(DatabaseContext context)
        {
            this._context = context;
        }
        public TestUnitOfWork(IMiastoRepository miastoRepo)
        {
            this.miastoRepository = miastoRepo;
        }

        public TestUnitOfWork(IMiejsceRepository miejsceRepo)
        {
            this.miejsceRepository = miejsceRepo;
        }

        public IMiastoRepository MiastoRepository
        {
            get
            {
                if (this.miastoRepository == null)
                {
                    this.miastoRepository = new MiastoRepository(_context);
                }
                return this.miastoRepository;
            }
        }

        public IMiejsceRepository MiejsceRepository
        {
            get
            {
                if (this.miejsceRepository == null)
                {
                    this.miejsceRepository = new MiejsceRepository(_context);
                }
                return this.miejsceRepository;
            }
        }

        public IInwalidzkieRepository InwalidzkieRepository
        {
            get
            {
                if (this.inwalidzkieRepository == null)
                {
                    this.inwalidzkieRepository = new InwalidzkieRepository(_context);
                }
                return this.inwalidzkieRepository;
            }
        }

        public IParkingRepository ParkingRepository
        {
            get
            {
                if (this.parkingRepository == null)
                {
                    this.parkingRepository = new ParkingRepository(_context);
                }
                return this.parkingRepository;
            }
        }

        public IOpiekunRepository OpiekunRepository
        {
            get
            {
                if (this.opiekunRepository == null)
                {
                    this.opiekunRepository = new OpiekunRepository(_context);
                }
                return this.opiekunRepository;
            }
        }

        public IRezerwacjaRepository RezerwacjaRepository
        {
            get
            {
                if (this.rezerwacjaRepository == null)
                {
                    this.rezerwacjaRepository = new RezerwacjaRepository(_context);
                }
                return this.rezerwacjaRepository;
            }
        }

        public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
