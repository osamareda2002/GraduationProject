using GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MonthlyReportsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            var dailyActivity = await _context.DailyActivity.ToListAsync();
            
            List<DailyActivity> monthlyReport = new List<DailyActivity>();
            foreach (var report in dailyActivity)
            {
                if (report.traineeId == id && (DateTime.Today - report.date).TotalDays<=30)
                    monthlyReport.Add(report);
            }
            
            return Ok(monthlyReport);
        }
    }

}
