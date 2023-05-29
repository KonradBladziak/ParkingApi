using BLL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCControllers
{
    public class ParkingBLLMock : IWorkService
    {
        public int IleMiejscDodano { get; set; }

        public Task<string> DodajMiasto(string nazwa, string wojewodztwo)
        {
            throw new NotImplementedException();
        }

        public Task DodajMiejsca(int ilosc, int idParkingu)
        {
            IleMiejscDodano = ilosc;
            return Task.CompletedTask;
        }

        public Task DodajMiejscaInwalidzkie(int ilosc, int idParkingu, decimal rozmiarMiejsca)
        {
            throw new NotImplementedException();
        }

        public Task DodajOpiekunaDoParkingu(int idOpiekuna, int idParkingu)
        {
            throw new NotImplementedException();
        }

        public Task DodajParking(Parking parking, int iloscMiejsc, int iloscMiejscInwalidzkich, decimal rozmiarMiejscInwalidzkich)
        {
            throw new NotImplementedException();
        }

        public Task DodajParkingDoMiasta(int idParkingu, int idMiasta)
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

        public Task PrzedluzRezerwacje(int rezerwacjaId, DateTime doKiedy)
        {
            throw new NotImplementedException();
        }

        public Task Rezerwacja(DateTime odKiedy, DateTime doKiedy, int idMiejsca, string imie, string nazwisko)
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

        public Task<ICollection<Parking>> ZwrocParkingiDanegoOpiekuna(int opiekunId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Parking>> ZwrocParkingiWMiescie(int miastoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rezerwacja>> ZwrocRezerwacjeWDanymCzasie(DateTime odKiedy, DateTime doKiedy)
        {
            throw new NotImplementedException();
        }
    }
}
