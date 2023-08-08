using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IWorkServices
{
    public interface IMiejscaInwalidzkieService
    {
        Task<List<MiejsceInwalidzkie>> GetMiejscaInwalidzkie();
        Task<MiejsceInwalidzkie> GetMiejsceInwalidzkieById(int id);
        Task<MiejsceInwalidzkie> GetMiejsceInwalidzkieByIdDetails(int id);
        Task AddMiejsceInwalidzkie(MiejsceInwalidzkie miejsce);
        Task DeleteMiejsceInwalidzkie(MiejsceInwalidzkie miejsce);
        Task UpdateMiejsceInwalidzkie(MiejsceInwalidzkie miejsce);
    }
}
