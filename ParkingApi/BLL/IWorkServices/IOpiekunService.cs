using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IWorkServices
{
    public interface IOpiekunService
    {
        Task<List<Opiekun>> GetOpiekunowie();
        Task<Opiekun> GetOpiekunById(int id);
        Task AddOpiekun(Opiekun opiekun);
        Task DeleteOpiekun(Opiekun opiekun);
        Task UpdateOpiekun(Opiekun opiekun);
    }
}
