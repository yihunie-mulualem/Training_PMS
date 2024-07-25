using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PerMS.Controllers
{
    [Authorize]
    public class MonthController : Controller
    {
        private PerMSContext _context;
        public MonthController(PerMSContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/[controller]/GetMonth")]
        public async Task<ActionResult<IEnumerable<Month>>> GetMonths()
        {
            var months = await _context.Months.ToListAsync();

            if (months == null || months.Count == 0)
            {
                return NotFound(); 
            }

            return Ok(months); 
        }

    }
}
