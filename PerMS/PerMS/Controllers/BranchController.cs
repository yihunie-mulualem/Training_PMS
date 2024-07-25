using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Model;
using PerMS.Models;
using System.Data;
using System.Security.Claims;
namespace PerMS.Controllers
{
    [Authorize]
    [Authorize(Roles =  "2")]
    public class BranchController : Controller
    {
        private PerMSContext _context;
        private  Branchservice _service;
        public BranchController(PerMSContext context,Branchservice service)
        {
            _context = context;
            _service = service;
            _service.BranchAdded += OnBranchAdded;
            _service.BranchUpdate += OnBranchUpdate;
            _service.BranchDelete += OnBranchDelete;
        }
        [HttpGet]
        [Route("api/[controller]/GetBranches")]
        public async Task<ActionResult<IEnumerable<BussinesUnit>>> GetBranches()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
                var Branchs = await _context.BussinesUnits.ToListAsync();
                return Branchs; 
                // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetBranchesByID")]
        public async Task<ActionResult<BussinesUnit>> GetBranchesByID(int id)
        {
            try
            {
                var branches = await _context.BussinesUnits.FindAsync(id);
                return branches; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/Insertbranches")]
        public async Task<IActionResult> Insertbranches(BussinesUnit branches)
        {
            try
            {
               // await _context.BussinesUnits.AddAsync(branches);
                //await _context.SaveChangesAsync();
                await _service.AddBranchAsync(branches);

                return Ok("Inserted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public virtual void OnBranchAdded(Object sender, BussinesUnitEventArgs e)
        {
            try
            {
                Console.WriteLine($"We are adding the Branch on it+{ e.BussinesUnit_Name}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("not adding BussinessUnit");
            }
        }
        public virtual void OnBranchUpdate(Object sender,BussinesUnitEventArgs e)
        {
            try
            {
                Console.WriteLine($"Updating the Branch Data{e.BussinesUnit_Name}");
            }catch(Exception ex)
            {
                Console.WriteLine($"Can not Update {e.BussinesUnit_Name}");
            }
        }
        public virtual void OnBranchDelete(object sender,BussinesUnitEventArgs e)
        {
            try
            {
                Console.WriteLine($"Deleting the Branch is OK.{e.BussinesUnit_Name}");
            }
            catch
            {
                Console.WriteLine($"We can not Delete the bussinessunit");
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateBranch")]
        public async Task<IActionResult> UpdateBranch(BussinesUnit branch)
        {
            try
            {
                if (branch == null)
                {
                    return BadRequest("District object is null.");
                }
                var existingBranch = await _context.BussinesUnits.FindAsync(branch.Id);
                if (existingBranch == null)
                {
                    return NotFound($"Bracnh with ID {branch.Id} not found.");
                }
                existingBranch.BussinesUnit_Code = existingBranch.BussinesUnit_Code;
                existingBranch.BussinesUnit_Name = branch.BussinesUnit_Name;
                existingBranch.ClusterId = branch.ClusterId;
               // _context.BussinesUnits.Update(existingBranch);
                await _service.UpdateBranchAync(existingBranch);
             //   await _context.SaveChangesAsync();
                return Ok("District updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteBranch")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {
                BussinesUnit branch = await _context.BussinesUnits.FindAsync(id);
                await _service.DeleteBranchAsync(branch);
                //_context.BussinesUnits.Remove(branch);
              //  await _context.SaveChangesAsync();
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
