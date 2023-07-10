using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiastaController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public MiastaController(IUnitOfWork unitOfWork) 
        { 
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetWszyskieMiasta")]
        public async Task<IActionResult> GetAllMiasta() { 
        
            var res = unitOfWork.MiastoRepository.GetAllAsync().Result.ToList();

            return Ok(res);
        }

        [HttpGet("GetMiastoById/{id?}")]
        public async Task<IActionResult> GetMiastoById(int id)
        {
            var res = unitOfWork.MiastoRepository.GetByIdAsync(id).Result;

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> AddMiasto(string nazwa,string wojewodztwo) {

            var miasto = new Miasto {Nazwa = nazwa,Wojewodztwo = wojewodztwo };

            unitOfWork.MiastoRepository.AddAsync(miasto);

            return Ok(miasto);
        
        }


    }
}
