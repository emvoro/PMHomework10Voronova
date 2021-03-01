using Microsoft.AspNetCore.Mvc;
using PrimesWebService.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Primes.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimesController : Controller
    {
        private readonly PrimesService _primesService = new PrimesService();

        [HttpGet]
        [Route("{number}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> IsPrimeAsync(int number)
        {
            return await _primesService.IsPrime(number) ? Ok(HttpStatusCode.OK) : NotFound(HttpStatusCode.NotFound);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<string>> GetPrimesAsync(int? from, int? to)
        {
            if (from == null || to == null)
                return BadRequest("Arguments are invalid.");

            var primes = await _primesService.GetPrimes((int)from, (int)to);

            return Ok(string.Join(",", primes));
        }
    }
}
