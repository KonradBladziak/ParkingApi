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
            var result = await this.workService.ZwrocParkingiWMiescie(miastoId);
            return result;
        }

        [HttpPost("DodajParkingDoMiasta")]
        public async Task DodajParkingDoMiasta([FromForm] int idParkingu, int idMiasta)
        {
            await this.workService.DodajParkingDoMiasta(idParkingu, idMiasta);
        }


        [HttpPost("DodajParking")]
        public async Task DodajParking([FromForm] Parking parking, int iloscMiejsc, int iloscMiejscInwalidzkich, decimal rozmiarMiejscInwalidzkich)
        {
            await this.workService.DodajParking(parking, iloscMiejsc, iloscMiejscInwalidzkich, rozmiarMiejscInwalidzkich);
        }

        [HttpPost("DodajOpiekunaDoParkingu")]
        public async Task DodajOpiekunaDoParkingu(int idOpiekuna, int idParkingu)
        {
            await this.workService.DodajOpiekunaDoParkingu(idOpiekuna, idParkingu);
        }

        [HttpPost("UsunParking")]
        public async Task UsunParking(int idParkingu)
        {
            await this.workService.UsunParking(idParkingu);
        }
    }

}
