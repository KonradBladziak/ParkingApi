using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMiastoRepository MiastoRepository { get; }
        IParkingRepository ParkingRepository { get; }

        IMiejsceRepository MiejsceRepository { get; }

        IMiejsceInwalidzkieRepository MiejsceInwalidzkie { get; }

        IOpiekunRepository OpiekunRepository { get; }

        IRezerwacjaRepository RezerwacjaRepository { get; }

        Task SaveAsync();
    }
}
