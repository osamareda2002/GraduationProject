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
            var breakfast = await _context.Breakfasts.ToListAsync();
            var snack = await _context.Snacks.ToListAsync();
            var meal = await _context.Meals.ToListAsync();
            var dinner = await _context.Dinners.ToListAsync();
            var snack2 = await _context.AfterWorkMeals.ToListAsync();
            double dayCalories = 0;
            List<string> foodPlan = new List<string>();
            foodPlan.Add("Breakfast : ");
            foreach (var b in breakfast)
            {
                foodPlan.Add(b.Name);
                dayCalories += b.Calories;
            }

            foodPlan.Add("Snack : ");
            foreach (var s in snack)
            {
                foodPlan.Add(s.Name);
                dayCalories += s.Calories;
            }

            foodPlan.Add("Lunch : ");
            Random random = new Random();
            int index = random.Next(7);
            foreach (var item in foods)
            {
                if (item.MealId == index)
                {
                    foodPlan.Add(item.FoodName);
                    dayCalories += item.Calories;
                }
            }

            foodPlan.Add("After Work : ");
            foreach (var item in snack2)
            {
                foodPlan.Add(item.Name);
                dayCalories += item.Calories;
            }

            foodPlan.Add("Dinner : ");
            foreach (var d in dinner)
            {
                foodPlan.Add(d.Name);
                dayCalories += d.Calories;
            }

            return Ok(foodPlan);
        }
    }
}
