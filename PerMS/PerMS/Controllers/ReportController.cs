using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
namespace PerMS.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private PerMSContext _context;
        public ReportController(PerMSContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/[controller]/GetHierarchyGroup")]
        public async Task<ActionResult<IEnumerable<HierarchyGroup>>> GetHierarchyGroup()
        {
            try
            {
                var report = await _context.HierarchyGroups.ToListAsync();
                return report; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetClusterByID")]
        public async Task<ActionResult<Cluster>> GetClusterByID(int id)
        {
            try
            {
                var cluster = await _context.Clusters.FindAsync(id);
                return cluster; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/InsertCluster")]
        public async Task<IActionResult> InsertCluster(Cluster cluster)
        {
            try
            {

                await _context.Clusters.AddAsync(cluster);
                await _context.SaveChangesAsync();
                return Ok("Cluster Inserted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateCluster")]
        public async Task<IActionResult> UpdateCluster(Cluster cluster)
        {
            try
            {
                // Validate cluster object
                if (cluster == null)
                {
                    return BadRequest("cluster object is null.");
                }
                var existingCluster = await _context.Clusters.FindAsync(cluster.Id);
                if (existingCluster == null)
                {
                    return NotFound($"Bracnh with ID {cluster.Id} not found.");
                }
                existingCluster.Name = cluster.Name;
                existingCluster.Code = cluster.Code;
                // Assuming 'Name' is the property you want to update
                _context.Clusters.Update(existingCluster);
               await _context.SaveChangesAsync();
                return Ok("cluster updated successfully.");
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteCluster")]
        public IActionResult DeleteCluster(int id)
        {
            try
            {
                Cluster cluster = _context.Clusters.Find(id);
                _context.Clusters.Remove(cluster);
                _context.SaveChanges();
                return Ok("Cluster Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
