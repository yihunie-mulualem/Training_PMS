using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
namespace PerMS.Controllers
{
    [Authorize] // Authorize all actions in this controller
    public class DistrictController : Controller
    {
        private PerMSContext _context;
        public DistrictController(PerMSContext context)
        {
        _context= context;
        }
        [HttpGet]
        [Route("api/[controller]/GetDistricts")]
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
            try
            {
                var districts = await _context.Districts.ToListAsync();
                return districts; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetDistrictsByID")]
        public async Task<ActionResult<District>> GetDistrictsByID(int id)
        {
            try
            {
                var districts = await _context.Districts.FindAsync(id);
                return districts; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/InsertDistrict")]
        public IActionResult InsertDistrict(District district)
        {
           try{
                    _context.Districts.Add(district);
                    _context.SaveChanges();
                return Ok("Inserted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateDistrict")]
        public IActionResult UpdateDistrict(District district)
        {
            try
            {
                // Validate district object
                if (district == null)
                {
                    return BadRequest("District object is null.");
                }

                // Check if the district with the provided ID exists in the database
                var existingDistrict = _context.Districts.Find(district.Id);
                if (existingDistrict == null)
                {
                    return NotFound($"District with ID {district.Id} not found.");
                }

                // Update the existing district with the data from the provided district object
                existingDistrict.Name = district.Name; // Assuming 'Name' is the property you want to update
                existingDistrict.Code = district.Code;                   // You can update other properties similarly

                _context.Districts.Update(existingDistrict);
                _context.SaveChanges();

                // Return a success response
                return Ok("District updated successfully.");
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteDistrict")]
        public IActionResult DeleteDistrict(int id)
        {
            try
            {
                District district = _context.Districts.Find(id);
                _context.Districts.Remove(district);
                _context.SaveChanges();
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
