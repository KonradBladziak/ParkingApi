using DAL.Entity;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IMiastoRepository MiastoRepository { get; }
        IMiejsceRepository MiejsceRepository { get; } 
        IInwalidzkieRepository InwalidzkieRepository { get; }
        IParkingRepository ParkingRepository { get; }
        IOpiekunRepository OpiekunRepository { get; }
        IRezerwacjaRepository RezerwacjaRepository { get; }
    }
}
