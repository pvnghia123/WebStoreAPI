using AspNet.Security.OpenIdConnect.Primitives;
using IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebStoreAPI.Interface;
using WebStoreAPI.Models;

namespace WebStoreAPI.Repository
{
    public class AssessTokenRepository : IAcccessToken
    {
        public string GenerationToken(UserInfo user, IConfiguration _configuration)
        {
            ArrayList list = new ArrayList();
            list.Add("role:Create");
            list.Add("role:Update");
            list.Add("role:Delete");
            list.Add("role:Search");
            string listjson = JsonConvert.SerializeObject(list);

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
                new Claim("Email",user.Email),
                new Claim("Roles","role:Create"),
                new Claim("Roles", "role:Update"),
                new Claim("Roles", "role:Delete"),
                new Claim("Roles", "role:Search"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                calaims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

