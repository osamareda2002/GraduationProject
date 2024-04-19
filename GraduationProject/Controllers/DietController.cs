using GraduationProject.Models;
using GraduationProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DietController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            Trainee trainee = null;
            var trainees = await _context.Trainees.ToListAsync();
            foreach (var traine in trainees)
            {
                if (traine.TraineeId==id)
                {
                    trainee = traine;
                    break;
                }
            }
            int? cal = trainee.RequiredCalories;
            var foods = await _context.Foods.ToListAsync();
            List<string> foodPlan = new List<string>();
            var breakfast = await _context.Breakfasts.ToListAsync();
            var meal = await _context.Meals.ToListAsync();
            foreach (var b in breakfast)
                foodPlan.Add(b.Name);
            List<string>meals = new List<string>();
            foreach (var item in meal)
                meals.Add(item.Name);
            Random random = new Random();
            int index = random.Next(meals.Count);
            string randomItem = meals[index];
            foodPlan.Add(randomItem);
            int breakfastCalories = 260 + 155 + 201 + 79;
            cal = cal - (2 * breakfastCalories);
            foreach (var item in foods)
            {
                if(item.FoodName==randomItem)
                {
                    cal = (int?)(cal - item.Calories);
                    break;
                }
            }
            var fruit = await _context.Fruits.ToListAsync();
            var vegetable = await _context.Vegetables.ToListAsync();
            List<string>fruits = new List<string>();
            List<string>vegetables= new List<string>();
            foreach (var item in fruit) fruits.Add(item.Name);
            foreach (var item in vegetable) vegetables.Add(item.Name);
            index = random.Next(fruits.Count);
            randomItem = fruits[index];
            foodPlan.Add(randomItem);
            if(index == fruits.Count-1)foodPlan.Add(fruits[index - 1]);
            else foodPlan.Add(fruits[index+1]);
            index = random.Next(vegetables.Count);
            foodPlan.Add(vegetables[index]);
            if(index == vegetables.Count-1)  foodPlan.Add(vegetables[index-1]);
            else foodPlan.Add(vegetables[index+1]);
            return Ok(foodPlan);
        }
    }
}
