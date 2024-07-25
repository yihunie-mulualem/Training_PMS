using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
namespace PerMS.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private PerMSContext _context;
        public UserController(PerMSContext context)
        {
        _context= context;
        }
        [HttpGet]
        [Route("api/[controller]/GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var query = from e in _context.Users
                            join bu in _context.BussinesUnits on e.User_BussinesUnitId equals bu.Id into bussinessunits
                            from bu in bussinessunits.DefaultIfEmpty()
                            join em in _context.Employees on e.User_EmployeeId equals em.Id into employess
                            from em in employess.DefaultIfEmpty()
                            join rol in _context.Roles on e.User_RoleId equals rol.Id into roles
                            from rol in roles.DefaultIfEmpty()
                            select new
                            {
                             e.Id,
                             e.User_UserName,
                             e.User_Password,
                             e.User_FullName,
                            BussinessUnitName = bu != null ? bu.BussinesUnit_Name : "N/A",
                            Employee = em != null ? em.Employee_FullName : "N/A",

                            Role = rol != null ? rol.Role_Name : "N/A",

                            };
                var users = await query.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetUsersByID")]
        public async Task<ActionResult<User>> GetUsersByID(int id)
        {
            try
            {
                var users = await _context.Users.FindAsync(id);
                return users; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/InsertUser")]
        public IActionResult InsertUser(User user)
        {
           try{
                user.User_CreateDate = DateTime.Now;
                user.User_CreateBy = "Yihunie";
                user.User_Active = true;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                return Ok(" User Inserted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null.");
                }
                var existingUser = _context.Users.Find(user.Id);
                if (existingUser == null)
                {
                    return NotFound($"User with ID {user.Id} not found.");
                }

                return Ok("User Updated successfully.");
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                User user = _context.Users.Find(id);
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok("Deleting user Successfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
