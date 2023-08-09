using BLL.DTO;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IWorkServices
{
    public interface IMiastoService
    {
        Task<IEnumerable<Miasto>> GetMiasta();
        Task<Miasto> GetMiastoById(int id);
        Task<Miasto> GetMiastoByIdDetails(int id);
        Task AddMiasto(Miasto miasto);
        Task DeleteMiasto(Miasto miasto);
        Task UpdateMiasto(Miasto miasto);
        Task<IEnumerable<MiastoResponse>> GetMiastaResponse();
    } 
}
