using APBD25_Kolokwium_2.DTOs;
using APBD25_Kolokwium_2.Exceptions;
using APBD25_Kolokwium_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD25_Kolokwium_2.Controllers
{
    [Route("api/track-races")]
    [ApiController]
    public class TrackRacesController : ControllerBase
    {
        private readonly ITrackRacesService _dbService;
        public TrackRacesController(ITrackRacesService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("participants")]
        public async Task<IActionResult> PutRacer([FromBody] RequiredDto requiredDto, CancellationToken cancellationToken)
        {
            try
            {
               await _dbService.PutRacer(requiredDto, cancellationToken);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }


            return Created();
        }
    }
}
