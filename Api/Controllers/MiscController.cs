using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiscController : ControllerBase
    {
        private readonly MiscService _miscService;

        public MiscController(MiscService miscService)
        {
            _miscService = miscService;
        }

        [HttpGet("getSubscriptions")]
        public async Task<ActionResult<AppResponse<List<Subscription>>>> GetSubscriptions()
        {
            return await _miscService.GetSubscriptions();
        }

        [HttpGet("getDays")]
        public async Task<ActionResult<AppResponse<List<Day>>>> GetDays()
        {
            return await _miscService.GetDays();
        }
    }
}
