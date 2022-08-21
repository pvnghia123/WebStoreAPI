using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebStoreAPI.Interface;
using WebStoreAPI.Models;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IUserInfo IUserInfo;
        private IConfiguration _configuration;
        public TokenController (IUserInfo iUserInfo, IConfiguration configuration)
        {
            IUserInfo = iUserInfo;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Post(UserInfo _info)
        {
            if (_info != null && _info.Email != null &&_info.Password != null)
            {
                var user =  IUserInfo.GetUser(_info.Email, _info.Password);
                if (user != null)
                {
                    // create token
                    var calaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("Id",user.UserId.ToString()),
                        new Claim("FirstName", user.FistName),
                        new Claim("LastName",user.LastName),
                        new Claim("UserName",user.UserName),
                        new Claim("Email",user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        calaims,
                        expires: DateTime.UtcNow.AddMinutes(5),
                        signingCredentials: signIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            return BadRequest();
        }
    }
}
