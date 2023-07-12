using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IMiejsceInwalidzkieRepository : IRepository<MiejsceInwalidzkie>
    {
        Task<IEnumerable<MiejsceInwalidzkie>> GetAllAsync();
        Task<MiejsceInwalidzkie> GetByIdAsync(int id);

        void Add(MiejsceInwalidzkie miejsce);

        void Delete(MiejsceInwalidzkie miejsce);

        void Update(MiejsceInwalidzkie miejsce);

    }
}
