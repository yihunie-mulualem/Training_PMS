using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
namespace PerMS.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private PerMSContext _context;
        public DepartmentController(PerMSContext context)
        {
            _context = context;
        }
       [HttpGet]
        [Route("api/[controller]/GetDepartment")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            try
            {
                var query = from e in _context.Departments
                            join bu in _context.BussinesUnits on e.BussinesUnitId equals bu.Id into bussinessunits
                            from bu in bussinessunits.DefaultIfEmpty()
                            select new
                            {   e.Id,
                                e.Department_Name,
                                e.Department_Code,
                                BussinessUnitName = bu != null ? bu.BussinesUnit_Name : "N/A",
                            };
                var department = await query.ToListAsync();

                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetDepartmentByID")]
        public async Task<ActionResult<Department>> GetDepartmentByID(int id)
        {
            try
            {
                var GetDepartmentByID = await _context.Departments.FindAsync(id);
                return GetDepartmentByID; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/InsertDepartment")]
        public IActionResult InsertDepartment(Department Departments)
        {
            try
            {
                Departments.Department_DateCreated = DateTime.Now;
                Departments.Department_CreatedBy = "Yihunie";
                Departments.Department_Active = true;
                _context.Departments.Add(Departments);
                _context.SaveChanges();
                return Ok(" Departments Inserted  Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateDepartments")]
        public IActionResult UpdateBranch(Department departments)
        {
            try
            {
                // Validate district object
                if (departments == null)
                {
                    return BadRequest("departments object is null.");
                }
                var existingdepartments = _context.Departments.Find(departments.Id);
                if (existingdepartments == null)
                {
                    return NotFound($"Departments with ID {departments.Id} not found.");
                }
                existingdepartments.Department_Name = existingdepartments.Department_Name;
                existingdepartments.Department_Code = existingdepartments.Department_Code;
                existingdepartments.Department_CreatedBy = existingdepartments.Department_CreatedBy;
                existingdepartments.Department_DateCreated = existingdepartments.Department_DateCreated;
                existingdepartments.Department_Active = existingdepartments.Department_Active;
                _context.Departments.Update(existingdepartments);
                _context.SaveChanges();
                return Ok("Departments updated successfully.");
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteDepartments")]
        public IActionResult DeleteDepartments(int id)
        {
            try
            {
                Department Departments = _context.Departments.Find(id);
                _context.Departments.Remove(Departments);
                _context.SaveChanges();
                return Ok("Departments Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
