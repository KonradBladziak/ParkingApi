using BLL;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiastoController : ControllerBase
    {
        private readonly IWorkService workService;

        public MiastoController(IWorkService workService)
        {
            this.workService = workService;
        }

        [HttpPost("DodajMiasto")]
        public async Task<IActionResult> DodajMiasto(string nazwa,string wojewodztwo)
         => Ok(await this.workService.DodajMiasto(nazwa,wojewodztwo));

        [HttpPost("UsunMiasto")]
        public async Task UsunMiasto(int idMiasta)
        {
            await this.workService.UsunMiasto(idMiasta);
        }

    }
}
