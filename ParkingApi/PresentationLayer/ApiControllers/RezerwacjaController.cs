using BLL;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezerwacjaController : ControllerBase
    {
        private readonly IWorkService workService;

        public RezerwacjaController(IWorkService workService)
        {
            this.workService = workService;
        }

        [HttpPost("DodajRezerwacje")]
        public async Task DodajRezerwacje(DateTime odKiedy, DateTime doKiedy, int idMiejsca, string imie, string nazwisko)
        {
            await this.workService.Rezerwacja(odKiedy, doKiedy, idMiejsca, imie, nazwisko);
        }
        [HttpPost("OdwolajRezerwacje")]
        public async Task OdwolajRezerwacje(int idRezerwacji)
        {
            await this.workService.OdwolajRezerwacje(idRezerwacji);
        }
        [HttpPost("EdytujRezerwacje")]
        public async Task EdytujRezerwacje(Rezerwacja rezerwacja)
        {
            await this.workService.EdytujRezerwacje(rezerwacja);
        }
        [HttpPost("PrzedluzRezerwacje")]
        public async Task PrzedluzRezerwacje(int rezerwacjaId, DateTime doKiedy)
        {
            await this.workService.PrzedluzRezerwacje(rezerwacjaId, doKiedy);
        }
        [HttpGet("ZwrocRezerwacjeWDanymCzasie")]
        public async Task<IEnumerable<Rezerwacja>> ZwrocRezerwacjeWDanymCzasie(DateTime odKiedy, DateTime doKiedy)
        {
            var result = await this.workService.ZwrocRezerwacjeWDanymCzasie(odKiedy, doKiedy);
            return result;
        }
    }
}
