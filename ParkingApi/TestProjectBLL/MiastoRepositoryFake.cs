using DAL.Entity;
using DAL.IRepositories;
using NuGet.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    internal class MiastoRepositoryFake : IMiastoRepository
    {
        private List<Miasto> miasta = new List<Miasto>();


        public async Task DeleteMiasto(int? id)
        {
            var res = miasta.Find(x => x.Id == id);
            miasta.Remove(res);
        }

        public async Task<IEnumerable<Miasto>> GetMiasta()
        {
            return await Task.FromResult<IEnumerable<Miasto>>(miasta);
        }

        public async Task<Miasto> GetMiastoById(int? id)
        {
            return await Task.FromResult<Miasto>(miasta.Find(x => x.Id == id));
        }

        public Task<ICollection<Parking>> GetParkingi(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertMiasto(Miasto miasto)
        {
            miasta.Add(miasto);
        }

        public async Task UpdateMiasto(Miasto miasto)
        {
            int index = this.miasta.FindIndex(x => x.Id == miasto.Id);
            if (index != -1)
                miasta[index] = miasto;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
