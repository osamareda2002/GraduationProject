using GraduationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string mail)
        {
            var trainees = await _context.Trainees.ToListAsync();
            foreach (var traine in trainees)
            {
                if(traine.Gmail == mail)return Ok(traine.TraineeId);
            }
            return Ok("User Not Found");
        }
    }
}
