using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace PerMS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        [HttpGet("userinfo")]
        public IActionResult GetUserInfo()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
            var userRoleClaim = User.FindFirst(ClaimTypes.Role)?.Value;
            var hgroupClaim = User.FindFirst(ClaimTypes.SerialNumber)?.Value;

            // Return the claims as part of the response
            return Ok(new
            {
                UserId = userIdClaim,
                UserName = userNameClaim,
                UserRole = userRoleClaim,
                Hgroup = hgroupClaim
            });
        }
    }
}
