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
        private IAcccessToken AcccessToken;
        public TokenController (IUserInfo iUserInfo, IConfiguration configuration, IAcccessToken acccessToken)
        {
            IUserInfo = iUserInfo;
            _configuration = configuration;
            AcccessToken = acccessToken;
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
                    string token = AcccessToken.GenerationToken(user, _configuration);
                    return Ok(token);
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
