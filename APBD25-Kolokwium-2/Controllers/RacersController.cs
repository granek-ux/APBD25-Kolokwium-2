using APBD25_Kolokwium_2.Exceptions;
using APBD25_Kolokwium_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD25_Kolokwium_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacersController : ControllerBase
    {
        private readonly IDbService _dbService;
        public RacersController(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet("{id}/participations")]
        public async Task<IActionResult> GetRacers(int id, CancellationToken cancellationToken)
        {
            try
            {
                var ret = await _dbService.GetRaces(id, cancellationToken);
                return Ok(ret);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
