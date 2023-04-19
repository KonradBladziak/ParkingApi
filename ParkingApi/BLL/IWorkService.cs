using DAL.Entity;
using System.Threading.Tasks;

namespace BLL
{
    public interface IWorkService
    {
        //Miasto Controller
        Task<string> DodajMiasto(Miasto miasto);
        Task UsunMiasto(int id);
        //Parking Controller
        Task<ICollection<Parking>> ZwrocParkingiWMiescie(int miastoId);
        Task DodajParking(Parking parking, int iloscMiejsc, int iloscMiejscInwalidzkich, decimal rozmiarMiejscInwalidzkich);
        Task UsunParking(int idParkingu);
        Task DodajOpiekunaDoParkingu(int idOpiekuna, int idParkingu);
        //Miejsca Controller
        Task DodajMiejsca(int ilosc,int idParkingu);
        Task DodajMiejscaInwalidzkie(int ilosc, int idParkingu,decimal rozmiarMiejsca);
        
        //Opiekun Controller
        Task StworzOpiekuna(Opiekun opiekun);
        Task UsunOpiekuna(int idOpiekuna);
        Task<ICollection<Parking>> ZwrocParkingiDanegoOpiekuna(int opiekunId);
        //Rezerwacja Controller
        Task Rezerwacja(Rezerwacja rezerwacja);
        Task OdwolajRezerwacje(int idRezerwacji);
        Task EdytujRezerwacje(Rezerwacja rezerwacja);
        Task PrzedluzRezerwacje(int rezerwacjaId, DateTime doKiedy);
        Task<IEnumerable<Rezerwacja>> ZwrocRezerwacjeWDanymCzasie(DateTime odKiedy, DateTime doKiedy);
        
    }
}