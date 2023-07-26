using BLL.IWorkServices;
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
        private IMiastoService miastoService;

        public MiastaController(IMiastoService miastoService) 
        { 
            this.miastoService = miastoService;
        }

        [HttpGet("GetWszyskieMiasta")]
        public async Task<IActionResult> GetAllMiasta()
            => Ok(await miastoService.GetMiasta());

        [HttpGet("GetMiastoById/{id?}")]
        public async Task<IActionResult> GetMiastoById(int id)
        => Ok(await miastoService.GetMiastoById(id));


    }
}
