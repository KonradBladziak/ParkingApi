using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task DodajMiasto(Miasto miasto)
        {
           await this._unitOfWork.MiastoRepository.InsertMiasto(miasto);
        }

        public async Task DodajMiejsca(int ilosc, int idParkingu)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < ilosc; i++)
                {
                    Miejsce miejsce = new Miejsce();
                    miejsce.ParkingId = idParkingu;
                    this._unitOfWork.MiejsceRepository.InsertMiejsce(miejsce);
                }
            });
            
        }

        public Task DodajMiejscaInwalidzkie(int ilosc, int idParkingu)
        {
            throw new NotImplementedException();
        }

        public Task DodajOpiekunaDoParkingu(int idOpiekuna, int idParkingu)
        {
            throw new NotImplementedException();
        }

        public Task DodajParking(Parking parking, int iloscMiejsc, int iloscMiejscInwalidzkich)
        {
            throw new NotImplementedException();
        }

        public Task EdytujRezerwacje(Rezerwacja rezerwacja)
        {
            throw new NotImplementedException();
        }

        public Task OdwolajRezerwacje(int idRezerwacji)
        {
            throw new NotImplementedException();
        }

        public Task Rezerwacja(Rezerwacja rezerwacja)
        {
            throw new NotImplementedException();
        }

        public Task StworzOpiekuna(Opiekun opiekun)
        {
            throw new NotImplementedException();
        }

        public Task UsunMiasto(int id)
        {
            throw new NotImplementedException();
        }

        public Task UsunOpiekuna(int idOpiekuna)
        {
            throw new NotImplementedException();
        }

        public Task UsunParking(int idParkingu)
        {
            throw new NotImplementedException();
        }

        /// ///////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task PrzedluzRezerwacje(int rezerwacjaId, DateTime doKiedy)
        {
            var rezerwacja = await this._unitOfWork.RezerwacjaRepository.GetRezerwacjaById(rezerwacjaId);
            rezerwacja.Do = doKiedy;
            await this._unitOfWork.RezerwacjaRepository.UpdateRezerwacja(rezerwacja);
        }
        public async Task<ICollection<Parking>> ZwrocParkingiDanegoOpiekuna(int opiekunId)
        {
            var opiekun = await this._unitOfWork.OpiekunRepository.GetOpiekunById(opiekunId);
            var wynik = opiekun.Parkingi;
            return wynik;
        }

        public async Task<ICollection<Parking>> ZwrocParkingiWMiescie(int miastoId)
        {
            var miasto = await this._unitOfWork.MiastoRepository.GetMiastoById(miastoId);
            var wynik = miasto.Parkingi;
            return wynik;
        }

        public async Task<IEnumerable<Rezerwacja>> ZwrocRezerwacjeWDanymCzasie(DateTime odKiedy, DateTime doKiedy)
        {
            var rezerwacje = await this._unitOfWork.RezerwacjaRepository.GetRezerwacje();
            var wynik = rezerwacje.Where(r => r.Od >= odKiedy && r.Do <= doKiedy);
            return wynik;
        }

    }
}
