using BLL.IWorkServices;
using DAL.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpiekunowieController : ControllerBase
    {
        private IOpiekunService opiekunService;

        public OpiekunowieController(IOpiekunService opiekunService)
        {
            this.opiekunService = opiekunService;
        }

        [HttpGet("GetWszyscyOpiekunowie")]
        public async Task<IActionResult> GetAllOpiekunowie()
            => Ok (await opiekunService.GetOpiekunowie());

        [HttpGet("GetOpiekunById/{id?}")]
        public async Task<IActionResult> GetOpiekunById(int id)
            => Ok(await opiekunService.GetOpiekunById(id));
    }
}
