using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerMS.DBContext;
using PerMS.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PerMS.Controllers
{
    [Authorize]   
    public class FisicalYearController : Controller
    {
        private PerMSContext _context;

        public FisicalYearController(PerMSContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/[controller]/GetFiscalYear")]
        public async Task<ActionResult<IEnumerable<FiscalYear>>> GetFiscalYear()
        {
            var Years = await _context.FiscalYears.ToListAsync();

            if (Years == null || Years.Count == 0)
            {
                return NotFound(); 
            }

            return Ok(Years);
        }
    }
}
