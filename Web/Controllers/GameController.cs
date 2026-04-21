using Microsoft.AspNetCore.Mvc;

namespace MojeVlastniStranka.Web.Controllers
{
    /// <summary>
    /// API for CaffeeCash game. Provides endpoints for game-related operations, such as retrieving the current game version.
    /// </summary>
    [Route("api/game")]
    [ApiController]
    public class GameController : BaseController
    {
        private const string CurrentVersion = "0.9.4";

        [HttpGet("version")]
        public IActionResult GetVersion()
        {
            return Ok(new { version = CurrentVersion });
        }
    }
}
