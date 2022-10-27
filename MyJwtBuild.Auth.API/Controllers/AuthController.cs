using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyJwtBuild.BUSINESS.Interfaces;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyJwtBuild.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AuthController(IConfiguration configuration, IUserService userService, IRoleService roleService)
        {
            _configuration = configuration;
            _userService = userService;
            _roleService = roleService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> CheckIsAdmin()
        {
            return Ok();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> LoginFromUsSystem(User user)
        {
            if (user != null && user.UserName != null && user.PasswordHash != null)
            {
                var tempUser = await _userService.GetUserForLoginAsync(user);
                if (tempUser != null)
                {
                    Role userRole = await _roleService.GetUserRoleByUserIdAsync(tempUser.Id);
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                        new Claim(ClaimTypes.Role , userRole.Name),

                        new Claim("Id", tempUser.Id.ToString()),
                        new Claim("UserName", tempUser.UserName),
                        new Claim("Password", tempUser.PasswordHash)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                        expires: DateTime.Now.AddMinutes(20), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
