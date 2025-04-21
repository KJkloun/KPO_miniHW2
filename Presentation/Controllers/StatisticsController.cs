using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet]
        public IActionResult Get() => Ok(_statisticsService.GetStatistics());
    }
}