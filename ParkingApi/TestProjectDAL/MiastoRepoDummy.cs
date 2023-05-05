using DAL.DataContext;
using DAL.Entity;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDAL
{
    public class MiastoRepoDummy : IMiastoRepository
    {
        public Task DeleteMiasto(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Miasto>> GetMiasta()
        {
            throw new NotImplementedException();
        }

        public Task<Miasto> GetMiastoById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Parking>> GetParkingi(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertMiasto(Miasto miasto)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMiasto(Miasto miasto)
        {
            throw new NotImplementedException();
        }
    }
}
