using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IInwalidzkieRepository : IDisposable
    {
        Task <ICollection<MiejsceInwalidzkie>> GetMiejscaInwalidzkie();
        Task <MiejsceInwalidzkie> GetMiejsceInwalidzkieById(int? id);
        Task <Miejsce> GetMiejsceById(int? id);
        Task <ICollection<Miejsce>> GetMiejsca();
        Task InsertMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie);
        Task UpdateMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie);
        Task DeleteMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie);
        Task Save();
    }
}
