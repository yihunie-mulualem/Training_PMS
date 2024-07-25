using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Model;
using PerMS.Models;
using System.Globalization;
using System.Security.Claims;
namespace PerMS.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private PerMSContext _context;
        private EmployeeService _service;
        public EmployeeController(PerMSContext context,EmployeeService service)
        {
             _context= context;
            _service = service;
            _service.EmployeeAdded += OnEmployeeAdded;
            _service.EmployeeUpdate += OnUpdateEmployee;
            _service.EmployeeDelete += OnEmployeeDelete;
        }
        [HttpGet]
        [Route("api/[controller]/GetEmployes")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployes()
        {
            try
            {
                var query = from e in _context.Employees
                            join jp in _context.JobPositions on e.JobPositionId equals jp.Id into jobPositions
                            from jp in jobPositions.DefaultIfEmpty()
                            join bu in _context.BussinesUnits on e.BussinesUnitId equals bu.Id into businessUnits
                            from bu in businessUnits.DefaultIfEmpty()
                            join Hr in _context.HierarchyGroups on e.HierarchyGroupId equals Hr.Id into hierarchyGroups
                            from Hr in hierarchyGroups.DefaultIfEmpty()
                            select new
                            {
                                e.Id,
                                e.MainID,
                                e.Employee_FullName,
                                e.Employee_Gender,
                                e.Employee_EmploymentType,
                                e.Employee_EmployeeStatus,
                                e.Employee_GradeLevel,
                                e.Employee_Remark,
                                e.Employee_CreatedBy,
                                e.Employee_DateCreated,
                                e.Employee_Active,
                                e.Employee_ContractExpiryDate,
                                JobPositionTitle = jp != null ? jp.JobPosition_Title : "N/A",
                                BussinesUnitName = bu != null ? bu.BussinesUnit_Name : "N/A",
                                HierarchyGroupName = Hr != null ? Hr.HierarchyGroup_Name : "N/A"
                            };

                var employees = await query.ToListAsync();

                return Ok(employees); // Return the list of employees as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetEmployesByID")]
        public async Task<ActionResult<Employee>>GetEmployesByID(int id)
         {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                return employee; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetEmployeeByHierarchygroup")]
        public async Task<ActionResult<Employee>> GetEmployeeByHierarchygroup()
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userNameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
                var userRoleClaim = User.FindFirst(ClaimTypes.Role)?.Value;
                var hgroupClaim = User.FindFirst(ClaimTypes.SerialNumber)?.Value;
                int HierarchyGroup = Convert.ToInt32(hgroupClaim);
                var query = from e in _context.Employees.Where(e=>e.HierarchyGroupId== HierarchyGroup)
                            select new
                            {
                                e.Id,
                                e.MainID,
                                e.Employee_FullName,
                                e.Employee_Gender,
                                e.Employee_EmploymentType,
                                e.Employee_EmployeeStatus,
                                e.Employee_GradeLevel,
                                e.Employee_Remark,
                                e.Employee_CreatedBy,
                                e.Employee_DateCreated,
                                e.Employee_Active,
                                e.Employee_ContractExpiryDate,
                            };

                var employees = await query.ToListAsync();

                if (employees == null)
                {
                    return NotFound("Employee not found.");
                }

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return Ok("Not found");
            }
        }
        [HttpPost]
        [Route("api/[controller]/InsertEmployee")]
        public async Task< IActionResult> InsertEmployee(Employee employee)
        {
           try
            {
                employee.Employee_Active = true;
                employee.Employee_CreatedBy = "Yihunie";
                employee.Employee_CreatedBy = "Yihunie";
                employee.Employee_DateCreated = DateTime.Now;
                //   _context.Employees.Add(employee);
                // _context.SaveChanges();
               await  _service.AddEmployeeAsync(employee);
                return Ok("Employee Inserted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public virtual void OnEmployeeAdded(object sender,EmployeeEventArgs e)
        {
            Console.WriteLine($"Employee Inserted:{e.Employee_FullName}");
        }
        public virtual void OnUpdateEmployee(object sender,EmployeeEventArgs e)
        {
            Console.WriteLine($"Employee Updated:{e.Employee_FullName}");
        }
        public virtual void OnEmployeeDelete(object sender, EmployeeEventArgs e)
        {
            Console.WriteLine($"Employee Deleted");
        }
        [HttpPut]
        [Route("api/[controller]/UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                // Validate user object
                if (employee == null)
                {
                    return BadRequest("employee object is null.");
                }
                var existingemployee = _context.Employees.Find(employee.Id);
                if (existingemployee == null)
                {
                    return NotFound($"Employee with ID {employee.Id} not found.");
                }
                await _service.UpdateEmployeeAync(employee);
                return Ok("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                Employee employes =await _context.Employees.FindAsync(id);
                //_context.Employees.Remove(employes);
                //_context.SaveChanges();
                await _service.DeleteEmployeeAsync(employes);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
