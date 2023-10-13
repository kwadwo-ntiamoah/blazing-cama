using Data.DTOs;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMgmt : ControllerBase
    {
        private readonly UserMgmtService _userMgmtService;

        public UserMgmt(UserMgmtService userMgmtService)
        {
            _userMgmtService = userMgmtService;
        }

        [HttpPost("token")]
        public async Task<ActionResult<AppResponse<Tokens>>> Login(LoginDto model)
        {
            return await _userMgmtService.Login(model);
        }
    }
}
