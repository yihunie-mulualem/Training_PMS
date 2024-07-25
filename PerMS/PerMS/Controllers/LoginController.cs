using Microsoft.AspNetCore.Mvc;
using PerMS.DBContext;
using PerMS.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PerMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authService;
        private PerMSContext _context;

        public LoginController(AuthService authService,PerMSContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost]
        [Route("api/[controller]/login")]
        public IActionResult Login(Login model)
        {
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Username and password cannot be null or empty.");
            }
            var user = _context.Users.FirstOrDefault(u => u.User_UserName == model.UserName && u.User_Password == model.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            var token = _authService.GenerateJwtToken(user.Id.ToString(), user.User_UserName, user.User_FullName, user.User_RoleId.ToString());
            return Ok(new { Token = token });
        }
    }
}
