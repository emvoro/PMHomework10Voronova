using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Primes.WebService.Controllers
{
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet("/")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<string> ShowStatus()
        {
            return Ok(" Primes app by PMA student Voronova Emilia");
        }
    }
}
