using BLL;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IWorkService workService;

        public ParkingController(IWorkService workService)
        {
            this.workService = workService;
        }

        [HttpGet("ZwrocParkingiWMiescie")]
        [Route("api/[controller]/ZwrocParkingiWMiescie")]
        public async Task<IActionResult> DodajMiasto([FromForm] Miasto miasto)
         => Ok(await this.workService.DodajMiasto(miasto));

        public async Task<ICollection<Parking>> ZwrocParkingiWMiescie([FromBody]int miastoId)
        {
            return await this.workService.ZwrocParkingiWMiescie(miastoId);
        }
    }

}
