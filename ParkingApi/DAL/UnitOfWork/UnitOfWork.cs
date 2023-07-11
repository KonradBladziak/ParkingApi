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

        public UnitOfWork(DatabaseContext databaseContext, IMiastoRepository miastoRepository)
        {
            this.databaseContext = databaseContext;
            this.miastoRepository = miastoRepository;
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

        public async Task SaveAsync() {
            
            await databaseContext.SaveChangesAsync();
        
        }
    }
}
