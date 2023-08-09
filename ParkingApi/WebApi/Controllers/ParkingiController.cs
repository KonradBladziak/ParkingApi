using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingiController : ControllerBase
    {
        private IParkingService parkingService;
        private IMiastoService miastoService;
        public ParkingiController(IParkingService parkingService, IMiastoService miastoService)
        {
            this.parkingService = parkingService;
            this.miastoService = miastoService; 
        }

        [HttpGet("GetWszystkieParkingiWMiescie/{id}")]
        public async Task<IActionResult> GetAllParkingi(int id)
        => Ok(await parkingService.GetParkingiResponse(id));

        [HttpGet("GetParkingById/{id?}")]
        public async Task<IActionResult> GetParkingById(int id)
            => Ok(await parkingService.GetParkingiById(id));


        [HttpPost("DodajParking")]
        public async Task<IActionResult> AddParking(string nazwaParkingu,string adres, int idMiasta, int idOpiekuna)
        {
            await parkingService.AddParking(nazwaParkingu, adres, idMiasta, idOpiekuna);

            return Ok("Dodano parking");
        }


        [HttpDelete("UsunParking/{id?}")]
        public async Task<IActionResult> DeleteParkingById(int id)
        {
            var parking = await parkingService.GetParkingiById(id);

            await parkingService.DeleteParking(parking);
            
            return Ok("Usunieto");    
        }

        [HttpPost("AddMiejsca")]
        public async Task<IActionResult> AddMiejsca(int id, int count)
            => Ok(await parkingService.AddMiejsca(id,count));

    }
}
