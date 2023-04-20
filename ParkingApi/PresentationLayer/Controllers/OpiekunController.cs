using BLL;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OpiekunController
    {
        private readonly IWorkService workService;

        public OpiekunController(IWorkService workService)
        {
            this.workService = workService;
        }

        [HttpPost("StworzOpiekuna")]
        public async Task StworzOpiekuna(string imie,string nazwisko)
        {
            await workService.StworzOpiekuna(new Opiekun {Imie = imie,Nazwisko = nazwisko });
        }

        [HttpPost("UsunOpiekuna")]
        public async Task UsunOpiekuna(int idOpiekuna)
        {
            await workService.UsunOpiekuna(idOpiekuna);
        }

        [HttpPost("ZwrocParkingiDanegoOpiekuna")]
        public async Task<Array> ZwrocParkingiDanegoOpiekuna(int idOpiekuna)
        {
            var res = workService.ZwrocParkingiDanegoOpiekuna(idOpiekuna).Result.ToArray();
            return res;
        }

    }
}
