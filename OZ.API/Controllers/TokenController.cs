using OZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

namespace OZ.Api.Controllers
{
    [Route("api/Token")]
    
    public class TokenController : Controller
    {
        private IConfiguration _config;
        IUserMap userMap;
        public TokenController(IConfiguration config, IUserMap map)
        {
            _config = config;
            userMap = map;
        }
        [AllowAnonymous]
        [HttpPost]
        public dynamic Post([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);
            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { userid = user.OID, 
                    place = user.PlaceID, 
                    FullName = user.FullName,
                    isAdmin = user.Admin,
                    placeId = user.PlaceID,
                    ManageCityID = user.ManageCityID,
                    ManageCityTypeID = user.ManageCityTypeID,
                    PlaceName = user.PlaceName,
                    token = tokenString,
                });
            }
            return response;
        }
        private string BuildToken(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("PlaceID", user.PlaceID.ToString()),
                //new Claim("PlaceName", user.PlaceName.ToString()),

                new Claim("ManageCityID", user.ManageCityID.ToString())// Like this
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddDays(3),
              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserViewModel Authenticate(LoginViewModel login)
        {           
            UserViewModel user = userMap.CheckLogin(login.username, login.password);
            
            return user;
        }
    }
}
