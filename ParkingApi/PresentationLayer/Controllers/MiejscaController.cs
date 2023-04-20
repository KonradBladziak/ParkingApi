using BLL;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiejscaController : ControllerBase
    {
        private readonly IWorkService workService;

        public MiejscaController(IWorkService workService)
        {
            this.workService = workService;
        }

        //[HttpPost("DodajMiejsca")]
        //public async Task<IActionResult> DodajMiejsca(int ilosc,int idParkingu)
        // => Ok(await this.workService.DodajMiejsca(ilosc,idParkingu));


        //[HttpPost("DodajMiejscaInwalidzkie")]
        //public async Task<IActionResult> DodajMiejscaInwalidzkie(int ilosc, int idParkingu, decimal rozmiarMiejsca)
        // => Ok(await this.workService.DodajMiejscaInwalidzkie(ilosc, idParkingu, rozmiarMiejsca));

    }
}
