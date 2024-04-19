using GraduationProject.Dtos;
using GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TraineesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var trainees = await _context.Trainees.ToListAsync();
            return Ok(trainees);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddTraineeDto dto)
        {
            var trainee = new Trainee();
            trainee = dto.trainee;
            int age = (DateTime.Today.Year - trainee.DateOfBirth.Year);
            
            if (dto.trainee.Gender=="Male")
                trainee.RequiredCalories = (int?)((10 * trainee.Weight) + (6.25 * trainee.Height) - (5 * age) + 5);
            else
                trainee.RequiredCalories = (int?)((10 * trainee.Weight) + (6.25 * trainee.Height) - (5 * age) - 161);
            if (trainee.FitnessLevel == "low")
                trainee.RequiredCalories = (int?) (trainee.RequiredCalories * 1.375);
            else if(trainee.FitnessLevel=="medium")
                trainee.RequiredCalories = (int?) (trainee.RequiredCalories * 1.375);
            else
                trainee.RequiredCalories = (int?) (trainee.RequiredCalories * 1.725);
            if (trainee.Purpose == "Muscle Dehydration")
                trainee.RequiredCalories -= 650;
            else if (trainee.Purpose == "Body Building")
                trainee.RequiredCalories += 500;
            await _context.AddAsync(trainee);
            _context.SaveChanges();
            return Ok(trainee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, AddTraineeDto dto)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
                return NotFound($"No Trainee was Found with ID : {id}");

            trainee.Gmail = dto.trainee.Gmail;
            //trainee.Password = dto.trainee.Password;
            trainee.Gender = dto.trainee.Gender;
            trainee.Purpose = dto.trainee.Purpose;
            //trainee.HasTools = dto.trainee.HasTools;
            trainee.DateOfBirth = dto.trainee.DateOfBirth;
            trainee.Height = dto.trainee.Height;
            trainee.Weight = dto.trainee.Weight;
            trainee.FitnessLevel = dto.trainee.FitnessLevel;
            trainee.RequiredCalories = dto.trainee.RequiredCalories;
            trainee.AvailabaleDays = dto.trainee.AvailabaleDays;
            trainee.TraineeSports = dto.trainee.TraineeSports;
            trainee.TraineeFoods = dto.trainee.TraineeFoods;

            _context.SaveChanges();
            return Ok(trainee);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
                return NotFound($"No Trainee was Found with ID : {id}");
            _context.Trainees.Remove(trainee);
            _context.SaveChanges();
            return Ok(trainee);

        }
    }
}
