using APBD25_Kolokwium_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD25_Kolokwium_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDbService _dbService;
        public OrderController(IDbService dbService)
        {
            _dbService = dbService;
        }

    }
}
