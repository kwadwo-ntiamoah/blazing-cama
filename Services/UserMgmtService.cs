using Data.DTOs;
using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserMgmtService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTService _jWT;

        public UserMgmtService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JWTService jWT)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jWT = jWT;
        }

        public async Task<AppResponse<Tokens>> Login(LoginDto model)
        {
            var response = new AppResponse<Tokens>();

            try
            {
                var user = await _userManager.FindByEmailAsync(model.Username);

                   

                response.Message = "Invalid login attempt";
                response.Status = HttpStatusCode.Unauthorized;

                return response;
            }
            catch (Exception)
            {
                response.Message = "An error occurred. Try again later";
                response.Status = HttpStatusCode.InternalServerError;

                return response;
            }
        }
    }
}
