using DAL.Entity;

namespace BLL
{
    public interface IWorkService
    {
        Task DodajMiasto(Miasto miasto);
        Task UsunMiasto(int id);
        Task DodajParking(Parking parking, int iloscMiejsc, int iloscMiejscInwalidzkich);
        Task UsunParking(int idParkingu);
        Task DodajMiejsca(int ilosc,int idParkingu);
        Task DodajMiejscaInwalidzkie(int ilosc, int idParkingu);
        Task DodajOpiekunaDoParkingu(int idOpiekuna,int idParkingu);
        Task StworzOpiekuna(Opiekun opiekun);
        Task UsunOpiekuna(int idOpiekuna);
        Task Rezerwacja(Rezerwacja rezerwacja);
        Task OdwolajRezerwacje(int idRezerwacji);
        Task EdytujRezerwacje(Rezerwacja rezerwacja);
    }
}