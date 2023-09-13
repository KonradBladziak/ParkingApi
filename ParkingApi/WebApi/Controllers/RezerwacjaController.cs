using BLL.DTO;
using BLL.IWorkServices;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezerwacjaController
    {
        private IRezerwacjeService rezerwacjeService;

        public RezerwacjaController(IRezerwacjeService rezerwacjeService)
        { 
            this.rezerwacjeService = rezerwacjeService;
        }

        [HttpPost("DodajRezerwacje")]
        public async Task DodajRezerwacje(RezerwacjaRequest rezerwacjaRequest)
        {
            await rezerwacjeService.AddRezerwacjaRequest(rezerwacjaRequest);
        }

    }
}
