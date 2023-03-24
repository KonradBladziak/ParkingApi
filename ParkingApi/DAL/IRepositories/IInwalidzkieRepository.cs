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
        ICollection<MiejsceInwalidzkie> GetMiejscaInwalidzkie();
        MiejsceInwalidzkie GetMiejsceInwalidzkieById(int id);
        Miejsce GetMiejsceById(int id);
        ICollection<Miejsce> GetMiejsca();
        void AddMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie);
        void UpdateMiejsceInwalidzkie(MiejsceInwalidzkie miejsceInwalidzkie);
        void DeleteMiejsceInwalidzkie(int id);
        void Save();
    }
}
