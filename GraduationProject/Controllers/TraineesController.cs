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
            /*
            var trainee = new Trainee();
            trainee = dto.trainee;
            */
            var trainee = new Trainee
            {
                Name = dto.Name,
                Gmail = dto.Gmail,
                Gender = dto.Gender,
                Purpose = dto.Purpose,
                DateOfBirth = dto.DateOfBirth,
                Height = dto.Height,
                Weight = dto.Weight,
                FitnessLevel = dto.FitnessLevel,
                RequiredCalories = dto.RequiredCalories,
                AvailabaleDays = dto.AvailabaleDays,
                TraineeSports = dto.TraineeSports,
                TraineeFoods = dto.TraineeFoods,
            };
            int age = (DateTime.Today.Year - trainee.DateOfBirth.Year);
            
            if (trainee.Gender=="Male")
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

            trainee.Gmail = dto.Gmail;
            //trainee.Password = dto.trainee.Password;
            trainee.Gender = dto.Gender;
            trainee.Purpose = dto.Purpose;
            //trainee.HasTools = dto.trainee.HasTools;
            trainee.DateOfBirth = dto.DateOfBirth;
            trainee.Height = dto.Height;
            trainee.Weight = dto.Weight;
            trainee.FitnessLevel = dto.FitnessLevel;
            trainee.RequiredCalories = dto.RequiredCalories;
            trainee.AvailabaleDays = dto.AvailabaleDays;
            trainee.TraineeSports = dto.TraineeSports;
            trainee.TraineeFoods = dto.TraineeFoods;

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
