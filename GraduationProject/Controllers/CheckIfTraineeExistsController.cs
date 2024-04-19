using GraduationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckIfTraineeExistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CheckIfTraineeExistsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync(string mail)
        {
            var trainees = await _context.Trainees.ToListAsync();
            foreach (var item in trainees)
            {
                if(item.Gmail == mail) return Ok(1);
            }
            return Ok(0);
        }
    }
}
