using Calculator.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> GenerateRefreshToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              null,
              expires: DateTime.Now.AddDays(10),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return token;
        }

        public async  Task<string> GenerateToken(User user)
        {
            var Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.Email, user.Email));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              Claims,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return token;

        }
    }
}
