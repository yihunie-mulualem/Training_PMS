using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
namespace PerMS.Controllers
{
    [Authorize]
    public class HeadMonthlyPMSController : Controller
    {
        private PerMSContext _context;
        public HeadMonthlyPMSController(PerMSContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/[controller]/GetHeadMonthlyPMS")]
        public async Task<ActionResult<IEnumerable<HeadQuarterlyPms>>> GetHeadQuarterlyPms()
        {
            try
            {
                var HeadMonthlyPMSs = await _context.HeadQuarterlyPms.ToListAsync();
                return HeadMonthlyPMSs; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/[controller]/HeadQuarterlyPmsByID")]
        public async Task<ActionResult<HeadQuarterlyPms>> HeadQuarterlyPmsByID(int id)
        {
            try
            {
                var HeadQuarterlyPms = await _context.HeadQuarterlyPms.FindAsync(id);
                return HeadQuarterlyPms; // Return the list of districts as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Internal server error: {ex.Message}");
            }
        }
   
        [HttpPost]
        [Route("api/[controller]/InsertHeadMonthlyPMSs")]
        public IActionResult InsertHeadMonthlyPMSs(HeadQuarterlyPms HeadQuarterlyPms)
        {
            try
            {

                _context.HeadQuarterlyPms.Add(HeadQuarterlyPms);
                _context.SaveChanges();
                return Ok("Inserted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/UpdateHeadQuarterlyPms")]
        public IActionResult UpdateHeadQuarterlyPms(HeadQuarterlyPms HeadQuarterlyPms)
        {
            try
            {
                // Validate district object
                if (HeadQuarterlyPms == null)
                {
                    return BadRequest("HeadMonthlyPMSs object is null.");
                }
                var existingHeadMonthlyPMSs = _context.HeadQuarterlyPms.Find(HeadQuarterlyPms.Id);
                if (existingHeadMonthlyPMSs == null)
                {
                    return NotFound($"HeadMonthlyPMSs with ID {HeadQuarterlyPms.Id} not found.");
                }
                existingHeadMonthlyPMSs.Analytical_skills = existingHeadMonthlyPMSs.Analytical_skills;
                existingHeadMonthlyPMSs.Ability_to_work_Under_pressure_and_Multi_Tasking_skills = existingHeadMonthlyPMSs.Ability_to_work_Under_pressure_and_Multi_Tasking_skills;
                existingHeadMonthlyPMSs.Accuracy_Efficiency_and_Time_Management = existingHeadMonthlyPMSs.Accuracy_Efficiency_and_Time_Management;
                existingHeadMonthlyPMSs.Oral_and_Written_Commuinication_Skills = existingHeadMonthlyPMSs.Oral_and_Written_Commuinication_Skills;
                existingHeadMonthlyPMSs.Collaboration_and_Team_work = existingHeadMonthlyPMSs.Collaboration_and_Team_work;
                existingHeadMonthlyPMSs.Dressing_Code_and_Attendance = existingHeadMonthlyPMSs.Dressing_Code_and_Attendance;
                existingHeadMonthlyPMSs.Knowledge_of_the_Job_and_Initiative_to_learn = existingHeadMonthlyPMSs.Knowledge_of_the_Job_and_Initiative_to_learn;
                existingHeadMonthlyPMSs.Confidentiality_Honesty_Integertiy = existingHeadMonthlyPMSs.Confidentiality_Honesty_Integertiy;
                existingHeadMonthlyPMSs.Innovation_and_Problem_Solving_Skills = existingHeadMonthlyPMSs.Innovation_and_Problem_Solving_Skills;
                existingHeadMonthlyPMSs.Attitude_toward_Internal_and_External_customers_Collagues_and_the_Bank = existingHeadMonthlyPMSs.Attitude_toward_Internal_and_External_customers_Collagues_and_the_Bank;
                existingHeadMonthlyPMSs.Additional_Comment_or_sugesstion_by_Supervisor = existingHeadMonthlyPMSs.Additional_Comment_or_sugesstion_by_Supervisor;
                existingHeadMonthlyPMSs.Employes_Comment_on_Evaluation = existingHeadMonthlyPMSs.Employes_Comment_on_Evaluation;
                existingHeadMonthlyPMSs.Name_of_Employee = existingHeadMonthlyPMSs.Name_of_Employee;
                existingHeadMonthlyPMSs.Employee_signature = existingHeadMonthlyPMSs.Employee_signature;
                existingHeadMonthlyPMSs.Employee_SignedDate = existingHeadMonthlyPMSs.Employee_SignedDate;
                existingHeadMonthlyPMSs.Name_of_Supervisor = existingHeadMonthlyPMSs.Name_of_Supervisor;
                existingHeadMonthlyPMSs.Supervisor_signature = existingHeadMonthlyPMSs.Supervisor_signature;
                existingHeadMonthlyPMSs.Supevisor_ApprovedDate = existingHeadMonthlyPMSs.Supevisor_ApprovedDate;
                existingHeadMonthlyPMSs.Employee_Id = existingHeadMonthlyPMSs.Employee_Id;
                existingHeadMonthlyPMSs.IsEmployeeApproved = existingHeadMonthlyPMSs.IsEmployeeApproved;
                existingHeadMonthlyPMSs.IsSupervisorApproved = existingHeadMonthlyPMSs.IsSupervisorApproved;

                _context.HeadQuarterlyPms.Update(existingHeadMonthlyPMSs);
                _context.SaveChanges();
                return Ok("existingHeadMonthlyPMSs Updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteHeadQuarterlyPms")]
        public IActionResult DeleteHeadQuarterlyPms(int id)
        {
            try
            {
                HeadQuarterlyPms HeadQuarterlyPms = _context.HeadQuarterlyPms.Find(id);
                _context.HeadQuarterlyPms.Remove(HeadQuarterlyPms);
                _context.SaveChanges();
                return Ok("HeadMonthlyPMSs Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
