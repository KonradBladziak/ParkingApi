using BLL.IWorkServices;
using BLL.WorkServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiejscaController : ControllerBase
    {
        private readonly IMiejsceService _miejsceService;

        public MiejscaController(IMiejsceService miejsceService)
        {
            _miejsceService = miejsceService;
        }

        [HttpGet("GetWszystkieMiejscaNaParkingu/{id}")]
        public async Task<IActionResult> GetAllMiejsca(int id, [FromQuery] DateTime od, [FromQuery] DateTime @do)
        => Ok(await _miejsceService.GetMiejscaResponse(id, od ,@do));
    }
}
