using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace FreeCourse.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                City = user.City
            });
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                City = signupDto.City,
                Email = signupDto.Email,
                UserName = signupDto.UserName
            }, signupDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(u => u.Description).ToList(), 400));
            }

            return NoContent();
        }
    }
}
