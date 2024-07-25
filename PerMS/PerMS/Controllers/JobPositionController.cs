using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Model;
using PerMS.Models;
namespace PerMS.Controllers
{
    [Authorize]
    public class JobPositionController : Controller
    {
        private PerMSContext _context;
        private JobpositionService _service;
        public JobPositionController(PerMSContext context,JobpositionService service)
        {
             _context= context;
            _service = service;
            _service.JobPositionAdded += OnJobPositionAdded;
            _service.JobPositionDelete += OnJobPositionDelete;
            _service.JobPositionUpdate += OnJobPositionUpdate;
        }
        [HttpGet]
        [Route("api/[controller]/GetJobPosition")]
        public async Task<ActionResult<IEnumerable<JobPosition>>> GetJobPosition()
        {
            try
            {
                var GetJobPosition = await _context.JobPositions.ToListAsync();
                return GetJobPosition; 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetJobPositionByID")]
        public async Task<ActionResult<JobPosition>> GetGetJobPositionByID(int id)
        {
            try
            {
                var JobPositions = await _context.JobPositions.FindAsync(id);
                return  Ok(JobPositions); // Return the list of JobPositions as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("api/[controller]/InsertJobPosition")]
        public async Task<IActionResult> InsertJobPosition(JobPosition JobPositions)
        {
           try{
                JobPositions.JobPosition_Active = "true";
                JobPositions.JobPosition_CreatedBy = "yihunie";
                JobPositions.JobPosition_DateCreated = DateTime.Now.ToString("dd-MMM-yyyy");
               await _service.AddJobPositionAsync(JobPositions);
                   //_context.JobPositions.Add(JobPositions);
                  //_context.SaveChanges();
                return Ok("JobPositions Inserted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateJobPositions")]
        public async Task<IActionResult> UpdateJobPositions(JobPosition JobPositions)
        {
            try
            {
                if (JobPositions == null)
                {
                    return BadRequest("JobPositions object is null.");
                }
                var existingJobPositions = _context.JobPositions.Find(JobPositions.Id);
                if (existingJobPositions == null)
                {
                    return NotFound($"JobPositions with ID {JobPositions.Id} not found.");
                }
                existingJobPositions.JobPosition_Code = JobPositions.JobPosition_Code; // Assuming 'Name' is the property you want to update
                existingJobPositions.JobPosition_Title = JobPositions.JobPosition_Title;                   // You can update other properties similarly
                existingJobPositions.JobPosition_Grade = JobPositions.JobPosition_Grade; // Assuming 'Name' is the property you want to update
                existingJobPositions.JobPosition_DateCreated = existingJobPositions.JobPosition_DateCreated;
                existingJobPositions.JobPosition_Active = existingJobPositions.JobPosition_Active;
                existingJobPositions.JobPosition_Category = existingJobPositions.JobPosition_Category;
                existingJobPositions.JobPosition_CreatedBy = existingJobPositions.JobPosition_CreatedBy;
                //  _context.JobPositions.Update(existingJobPositions);
                // _context.SaveChanges();
                await _service.UpdateJobPositionAync(existingJobPositions);
                return Ok("JobPositions updated successfully.");
            }
            catch (Exception ex)
            {
                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        public virtual void OnJobPositionUpdate(object sender,JobPositionEventArgs e)
        {
            Console.WriteLine("Updating the JObPosition");
        }
        public virtual void OnJobPositionDelete(object sender,JobPositionEventArgs e)
        {
            Console.WriteLine("Deleting JOb Position");
        }
        public virtual void OnJobPositionAdded(object sender,JobPositionEventArgs e)
        {
            Console.WriteLine("Adding JobPosition");
        }
        [HttpDelete]
        [Route("api/[controller]/DeleteJobPositions")]
        public async Task<IActionResult> DeleteJobPositions(int id)
        {
            try
            {
                JobPosition JobPositions = _context.JobPositions.Find(id);
                // _context.JobPositions.Remove(JobPositions);
                //_context.SaveChanges();
                await _service.DeleteJobPositionAsync(JobPositions);
                return Ok("JobPositions Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
