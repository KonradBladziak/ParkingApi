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

        [HttpPost("GetWszyskieMiasta")]
        public async Task<IActionResult> GetAllMiasta() { 
        
            var res = unitOfWork.MiastoRepository.GetAllAsync().Result.ToList();

            return Ok(res);
        }

        [HttpPost("AddMiasto")]
        public async Task<IActionResult> AddMiasto(string nazwa,string wojewodztwo) {

            var miasto = new Miasto {Nazwa = nazwa,Wojewodztwo = wojewodztwo };

            unitOfWork.MiastoRepository.Add(miasto);

            await unitOfWork.SaveAsync();

            return Ok(miasto);
        
        }

        [HttpGet("GetMiastoById/{id?}")]
        public async Task<IActionResult> GetMiastoById(int id)
        {
            var miasto = unitOfWork.MiastoRepository.GetByIdAsync(id).Result;

            return Ok(miasto);
        }

        [HttpDelete("UsunMiasto/{id?}")]
        public async Task<IActionResult> DeleteMiastoById(int id) 
        { 
            var miasto = unitOfWork.MiastoRepository.GetByIdAsync(id).Result;

            unitOfWork.MiastoRepository.Delete(miasto);

            await unitOfWork.SaveAsync();

            return Ok(miasto);
        
        }

        [HttpPut("UpdateMiasto/{id?}")]
        public async Task<IActionResult> UpdateMiastoById(int id,string nazwa,string wojewodztwo)
        {
            var miasto = unitOfWork.MiastoRepository.GetByIdAsync(id).Result;

            miasto.Nazwa = nazwa;
            miasto.Wojewodztwo = wojewodztwo;

            unitOfWork.MiastoRepository.Update(miasto);

            await unitOfWork.SaveAsync();

            return Ok(miasto);

        }


    }
}
