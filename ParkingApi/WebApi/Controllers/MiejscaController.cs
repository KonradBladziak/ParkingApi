using BLL.IWorkServices;
using BLL.WorkServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helper;

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

        [HttpPut("GetWszystkieMiejscaNaParkingu/{id}")]
        public async Task<IActionResult> GetAllMiejsca(int id, [FromBody] Data data)
        => Ok(await _miejsceService.GetMiejscaResponse(id, data.Start, data.End));
    }
}
