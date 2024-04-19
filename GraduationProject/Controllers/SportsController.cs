using GraduationProject.Dtos;
using GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        

        public SportsController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            
            var sports = await _context.Sports.ToListAsync();
            return Ok(sports);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddSportDto dto)
        {
            var sport = new Sport
            {
                SportName = dto.Name,
                CaloreisPerKg = dto.calories
            };
            await _context.Sports.AddAsync(sport);
            _context.SaveChanges();
            return Ok(sport);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, AddSportDto dto)
        {
            var sport = await _context.Sports.FindAsync(id);
            if (sport == null)
                return NotFound($"No Trainee was Found with ID : {id}");

            sport.SportName = dto.Name;
            sport.CaloreisPerKg = dto.calories;

            _context.SaveChanges();
            return Ok(sport);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var sport = await _context.Sports.FindAsync(id);
            if (sport == null)
                return NotFound($"No Trainee was Found with ID : {id}");
            _context.Sports.Remove(sport);
            _context.SaveChanges();
            return Ok(sport);

        }
    }

}
