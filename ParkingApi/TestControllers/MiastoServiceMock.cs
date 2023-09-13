using BLL.DTO;
using BLL.IWorkServices;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllers
{
    public class MiastoServiceMock : IMiastoService
    {
        List<Miasto> miasta = new List<Miasto>();

        public Task AddMiasto(Miasto miasto)
        {
            miasta.Add(miasto); 
            return Task.CompletedTask;
        }

        public Task DeleteMiasto(Miasto miasto)
        {
            miasta.Remove(miasto);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Miasto>> GetMiasta()
        {
            return Task.FromResult<IEnumerable<Miasto>>(miasta);
        }

        public Task<IEnumerable<MiastoResponse>> GetMiastaResponse()
        {
            throw new NotImplementedException();
        }

        public async Task<Miasto> GetMiastoById(int id)
        {

            var miasto = miasta.First(x => x.Id == id);

            if (miasto != null)
            {
                return miasto;
            }

            return null;

        }

        public Task<Miasto> GetMiastoByIdDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMiasto(Miasto miasto)
        {
            var _miasto = miasta.FirstOrDefault(x => x.Id == miasto.Id);

            miasta.Remove(_miasto);
            miasta.Add(miasto);

            return Task.CompletedTask;
        }
    }
}
