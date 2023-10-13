using Data.DTOs;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSubscriptionController : ControllerBase
    {
        private readonly UserSubscriptionService _userSubscriptionService;
        public UserSubscriptionController(UserSubscriptionService userSubscriptionService)
        {
            _userSubscriptionService = userSubscriptionService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<AppResponse<UserSubscription>>> AddUserSubscription(CreateUserSubDto dto)
        {
            return await _userSubscriptionService.AddUserSubscription("", dto);
        }

        [HttpPost("active")]
        public int ActivateUserSubscription(CreateUserSubDto dto)
        {
            return 1;
        }
    }
}
