using DAL.Entity;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    public class MiejsceRepositoryFake : IMiejsceRepository
    {
        private List<Miejsce> miejsca = new List<Miejsce>();

        public Task DeleteMiejsce(Miejsce miejsce)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Miejsce>> GetMiejsca()
        {
            return await Task.FromResult<ICollection<Miejsce>>(miejsca);
        }
        public Task<Miejsce> GetMiejscaById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Rezerwacja>> GetRezerwacje()
        {
            throw new NotImplementedException();
        }

        public async Task InsertMiejsce(Miejsce miejsce)
        {
            miejsca.Add(miejsce);
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMiejsce(Miejsce miejsce)
        {
            throw new NotImplementedException();
        }
    }
}
