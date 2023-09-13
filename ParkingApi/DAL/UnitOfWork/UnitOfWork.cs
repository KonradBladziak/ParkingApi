using DAL.DataContext;
using DAL.IRepository;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext databaseContext;

        private IMiastoRepository miastoRepository;
        private IParkingRepository parkingRepository;
        private IMiejsceRepository miejsceRepository;
        private IOpiekunRepository opiekunRepository;
        private IMiejsceInwalidzkieRepository miejsceInwalidzkieRepository;
        private IRezerwacjaRepository rezerwacjaRepository;

        public UnitOfWork(DatabaseContext databaseContext, IMiastoRepository miastoRepository = null, IParkingRepository parkingRepository = null, IMiejsceRepository miejsceRepository = null, IOpiekunRepository opiekunRepository = null, IMiejsceInwalidzkieRepository miejsceInwalidzkieRepository = null, IRezerwacjaRepository rezerwacjaRepository = null)
        {
            if (databaseContext != null)
            {
                this.databaseContext = databaseContext;
            }
            else
            {
                if (miastoRepository != null)
                {
                    this.miastoRepository = miastoRepository;
                }

                if (parkingRepository != null)
                {
                    this.parkingRepository = parkingRepository;
                }

                if (miejsceRepository != null)
                {
                    this.miejsceRepository = miejsceRepository;
                }

                if (opiekunRepository != null)
                {
                    this.opiekunRepository = opiekunRepository;
                }

                if (miejsceInwalidzkieRepository != null)
                {
                    this.miejsceInwalidzkieRepository = miejsceInwalidzkieRepository;
                }

                if (rezerwacjaRepository != null)
                {
                    this.rezerwacjaRepository = rezerwacjaRepository;
                }
            }
        }

        public IMiastoRepository MiastoRepository
        {
            get
            {
                if (this.miastoRepository == null)
                {
                    this.miastoRepository = new MiastoRepository(databaseContext);
                }
                return this.miastoRepository;
            }
        }

        public IParkingRepository ParkingRepository
        {
            get
            {
                if (this.parkingRepository == null)
                {
                    this.parkingRepository = new ParkingRepository(databaseContext);
                }
                return this.parkingRepository;
            }
        }

        public IMiejsceRepository MiejsceRepository
        {
            get
            {
                if (this.miejsceRepository == null)
                {
                    this.miejsceRepository = new MiejsceRepository(databaseContext);
                }
                return this.miejsceRepository;
            }
        }

        public IMiejsceInwalidzkieRepository MiejsceInwalidzkieRepository
        {
            get
            {
                if (this.miejsceInwalidzkieRepository == null)
                {
                    this.miejsceInwalidzkieRepository = new MiejsceInwalidzkieRepository(databaseContext);
                }
                return this.miejsceInwalidzkieRepository;
            }
        }

        public IOpiekunRepository OpiekunRepository
        {
            get
            {
                if (this.opiekunRepository == null)
                {
                    this.opiekunRepository = new OpiekunRepository(databaseContext);
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
                    this.rezerwacjaRepository = new RezerwacjaRepository(databaseContext);
                }
                return this.rezerwacjaRepository;
            }
        }

        public async Task SaveAsync()
        {

            await databaseContext.SaveChangesAsync();

        }
    }
}
