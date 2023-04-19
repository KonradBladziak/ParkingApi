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

        public async Task<string> DodajMiasto(Miasto miasto)
        {
           var miasta = _unitOfWork.MiastoRepository.GetMiasta().Result.Any(x => x.Nazwa == miasto.Nazwa);

            if (miasta == false) {

                await _unitOfWork.MiastoRepository.InsertMiasto(miasto);
                return $"Dodano miasto {miasto.Nazwa}";
            }
            else 
            { 
                return $"Miasto {miasto.Nazwa} już jest w bazie"; 
            }
           
        }

        public async Task UsunMiasto(int id)
        {
            await this._unitOfWork.MiastoRepository.DeleteMiasto(id);
        }

        public async Task DodajMiejsca(int ilosc, int idParkingu)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < ilosc; i++)
                {
                    Miejsce miejsce = new Miejsce { ParkingId = idParkingu };
                    this._unitOfWork.MiejsceRepository.InsertMiejsce(miejsce);
                }
            });
        }

        public async Task DodajMiejscaInwalidzkie(int ilosc, int idParkingu,decimal rozmiarMiejsca)
        {

            await Task.Run(() =>
            {
                for (int i = 0; i < ilosc; i++)
                {
                    Miejsce miejsce = new Miejsce { ParkingId = idParkingu };
                    this._unitOfWork.MiejsceRepository.InsertMiejsce(miejsce);

                    MiejsceInwalidzkie miejsceInwalidzkie = new MiejsceInwalidzkie { RozmiarMiejsca = rozmiarMiejsca, IdMiejsca = miejsce.Id };
                    this._unitOfWork.InwalidzkieRepository.InsertMiejsceInwalidzkie(miejsceInwalidzkie);

                    miejsce.MiejsceInwalidzkieId = miejsceInwalidzkie.Id;

                    this._unitOfWork.MiejsceRepository.UpdateMiejsce(miejsce);

                }
            });
        }

        public async Task DodajOpiekunaDoParkingu(int idOpiekuna, int idParkingu)
        {
            var opiekun = await _unitOfWork.OpiekunRepository.GetOpiekunById(idOpiekuna);

            opiekun.Parkingi.Add(await _unitOfWork.ParkingRepository.GetParkingById(idParkingu));
        }

        public async Task DodajParking(Parking parking, int iloscMiejsc, int iloscMiejscInwalidzkich,decimal rozmiarMiejscInwalidzkich)
        {
            await this._unitOfWork.ParkingRepository.InsertParking(parking);
            await DodajMiejsca(iloscMiejsc, parking.Id);
            await DodajMiejscaInwalidzkie(iloscMiejscInwalidzkich, parking.Id,rozmiarMiejscInwalidzkich);
        }

        public async Task EdytujRezerwacje(Rezerwacja rezerwacja)
        {
            await this._unitOfWork.RezerwacjaRepository.UpdateRezerwacja(rezerwacja);
        }

        public async Task OdwolajRezerwacje(int idRezerwacji)
        {
            await this._unitOfWork.RezerwacjaRepository.DeleteRezerwacja(idRezerwacji);
        }

        public async Task Rezerwacja(Rezerwacja rezerwacja)
        {
            await this._unitOfWork.RezerwacjaRepository.InsertRezerwacja(rezerwacja);
        }

        public async Task StworzOpiekuna(Opiekun opiekun)
        {
            await this._unitOfWork.OpiekunRepository.InsertOpiekun(opiekun);
        }

        

        public async Task UsunOpiekuna(int idOpiekuna)
        {
            await this._unitOfWork.OpiekunRepository.DeleteOpiekun(idOpiekuna);
        }

        public async Task UsunParking(int idParkingu)
        {
            var parking = await this._unitOfWork.ParkingRepository.GetParkingById(idParkingu);
            await this._unitOfWork.ParkingRepository.DeleteParking(parking);
        }

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
