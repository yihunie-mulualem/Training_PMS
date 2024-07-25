using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
namespace PerMS.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private PerMSContext _context;
        public RoleController(PerMSContext context)
        {
        _context= context;
        }
        [HttpGet]
        [Route("api/[controller]/GetRoles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                return roles; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetRolesByID")]
        public async Task<ActionResult<Role>> GetRolesByID(int id)
        {
            try
            {
                var roles = await _context.Roles.FindAsync(id);
                return roles; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/InsertRoles")]
        public IActionResult InsertRoles(Role roles)
        {
           try{
                roles.Role_LastModfDate = DateTime.Now;
                roles.Role_CreateDate = DateTime.Now;
                roles.Role_CreateBy = "Yihunie";
                roles.Role_LastModfBy = "Yihunie";
                roles.Role_Active = true;
                    _context.Roles.Add(roles);
                    _context.SaveChanges();
                return Ok("Roles Created Inserted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateRole")]
        public IActionResult UpdateRole(Role roles)
        {
            try
            {
                // Validate district object
                if (roles == null)
                {
                    return BadRequest("role object is null.");
                }
                var existingRole = _context.Roles.Find(roles.Id);
                if (existingRole == null)
                {
                    return NotFound($"role with ID {roles.Id} not found.");
                }
                existingRole.Role_Name = roles.Role_Name; // Assuming 'Name' is the property you want to update
                existingRole.Role_CreateDate = existingRole.Role_CreateDate;                   // You can update other properties similarly
                existingRole.Role_CreateBy = existingRole.Role_CreateBy;                   // You can update other properties similarly
                existingRole.Role_LastModfDate = existingRole.Role_LastModfDate;                   // You can update other properties similarly
                existingRole.Role_Active = existingRole.Role_Active; ;                   // You can update other properties similarly
                _context.Roles.Update(existingRole);
                _context.SaveChanges();

                // Return a success response
                return Ok("Role is Updated successfully.");
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteRole")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                Role roles = _context.Roles.Find(id);
                _context.Roles.Remove(roles);
                _context.SaveChanges();
                return Ok(" Role Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
