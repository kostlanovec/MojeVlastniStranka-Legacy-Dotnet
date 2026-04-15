using Microsoft.AspNetCore.Mvc;

namespace MojeVlastniStranka.Web.Controllers
{
    /// <summary>
    /// API pro hru CaffeCash.
    /// </summary>
    [Route("api/game")]
    [ApiController]
    public class GameController : BaseController
    {
        // Aktualizuj tuto konstantu při každém novém vydání hry.
        private const string CurrentVersion = "0.1.0";

        /// <summary>
        /// GET /api/game/version
        /// Vrátí aktuální verzi hry jako JSON.
        /// </summary>
        [HttpGet("version")]
        public IActionResult GetVersion()
        {
            return Ok(new { version = CurrentVersion });
        }
    }
}
