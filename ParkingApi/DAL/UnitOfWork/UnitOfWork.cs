using DAL.DataContext;
using DAL.IRepositories;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _context = new DatabaseContext();
        private IMiastoRepository miastoRepository;
        private IMiastoRepository miejsceRepository;
        private IMiastoRepository inwalidzkieRepository;
        private IMiastoRepository parkingRepository;
        private IMiastoRepository opiekunRepository;
        private IMiastoRepository rezerwacjaRepository;
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

        public IInwalidzkieRepository InwalidzkieRepository => throw new NotImplementedException();

        public IParkingRepository ParkingRepository => throw new NotImplementedException();

        public IOpiekunRepository OpiekunRepository => throw new NotImplementedException();

        public IRezerwacjaRepository RezerwacjaRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
