using BLL.DTO;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IWorkServices
{
    public interface IMiejsceService
    {
        Task<IEnumerable<Miejsce>> GetMiejsca();
        Task<Miejsce> GetMiejsceById(int id);
        Task<Miejsce> GetMiejsceByIdDetails(int id);
        Task AddMiejsce(Miejsce miejsce);
        Task DeleteMiejsce(Miejsce miejsce);
        Task UpdateMiejsce(Miejsce miejsce);
        Task<IEnumerable<MiejsceResponse>> GetMiejscaResponse(int parkingId, DateTime od, DateTime @do);
    }
}
