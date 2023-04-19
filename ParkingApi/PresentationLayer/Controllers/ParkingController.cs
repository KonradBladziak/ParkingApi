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
            return await this.workService.ZwrocParkingiWMiescie(miastoId);
        }
    }

}
