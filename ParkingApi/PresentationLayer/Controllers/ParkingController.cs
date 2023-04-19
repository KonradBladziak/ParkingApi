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
        public async Task<ICollection<Parking>> ZwrocParkingiWMiescie(int miastoId)
        {
            try
            {
                var result = await this.workService.ZwrocParkingiWMiescie(miastoId);
                if (result == null)
                {
                    throw new Exception("");
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("DodajParkingDoMiasta")]
        public async Task DodajParkingDoMiasta([FromForm]int idParkingu, int idMiasta)
        => Ok(this.workService.DodajParkingDoMiasta(idParkingu, idMiasta));

    }

}
