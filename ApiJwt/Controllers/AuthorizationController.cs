using ApiJwt.Models;
using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiJwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IConfiguration _configuration;
        public AuthorizationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("get-token")]
        public async Task<IActionResult> GetToken(AuthenticateRequest request, [FromServices] UserManager<User> userManager)
        {
            // Verificamos credenciales con Identity
            var user = await userManager.FindByNameAsync(request.UserName);

            if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                return Forbid();
            }

            var roles = await userManager.GetRolesAsync(user);

            // Generamos un token según los claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new { AccessToken = jwt });
        }

        [HttpGet("me")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize]
        public IActionResult Me([FromServices] IHttpContextAccessor contextAccessor)
        {
            var user = contextAccessor.HttpContext.User;

            return Ok(new
            {
                Claims = user.Claims.Select(s => new
                {
                    s.Type,
                    s.Value
                }).ToList(),
                user.Identity.Name,
                user.Identity.IsAuthenticated,
                user.Identity.AuthenticationType
            });
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(User user, [FromServices] UserManager<User> userManager)
        {
            var result = await userManager.CreateAsync(user, user.PasswordHash);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }



    }
}
