using Calculator.Application.Exceptions;
using Calculator.Application.Services;
using Calculator.Domain.Entities;
using Calculator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthController(IUserService userService,IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel data)
        {
            try
            {
                User user = await _userService.LoginCheck(data.Email, data.Password);
                user.AccessToken = await _authService.GenerateToken(user);
                //user.RefreshToken = await _authService.GenerateRefreshToken();
                //User updatedUser = await _userService.Update(user);
                //Response.Cookies.Append("Authorization", $"Barrer {user.AccessToken}");
                user.Password = "xxxx";
                return Ok(user);
            }
            catch (NotFoundException)
            {
                return NotFound("Invalid username or password");
            }
        }        
    }
}
