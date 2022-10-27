using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyJwtBuild.Data.API.Areas.Hasar.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Hasar")]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<ActionResult> GetHasarDatas()
        {
            return Ok("Hasar Datası");
        }
    }
}
