using GraduationProject.Dtos;
using GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddFoodReport dto)
        {
            /*var foodReport = new FoodReport();
            foodReport = dto.foodReport*/;
            var foodReport = new FoodReport
            {
                TraineeId = dto.TraineeId,
                DateOfOccurrence = dto.DateOfOccurrence,
                foodId = dto.foodId,
                quantity = dto.quantity,
            };
            await _context.AddAsync(foodReport);
            
            var dailyActivities = await _context.DailyActivity.ToListAsync();
            bool flag = false;
            foreach (var activity in dailyActivities)
            {
                if (activity.traineeId == foodReport.TraineeId && activity.date == foodReport.DateOfOccurrence)
                {
                    bool flag2 = false;
                    foreach (var f in activity.dailyFoodEaten)
                    {
                        if (f.foodId == foodReport.foodId)
                        {
                            flag2 = true;
                            f.quantity+= foodReport.quantity;
                        }
                    }
                    if (!flag2)
                    {
                        var food = new FoodEaten();
                        food.foodId = foodReport.foodId;
                        food.quantity = foodReport.quantity;
                        activity.dailyFoodEaten.Add(food);
                    }
                }
            }
            if (!flag)
            {
                var activity = new DailyActivity();
                activity.traineeId= foodReport.TraineeId;
                activity.date = foodReport.DateOfOccurrence;
                activity.dailyFoodEaten = new List<FoodEaten>{
                    new FoodEaten()
                    {
                        foodId = foodReport.foodId,
                        quantity = foodReport.quantity, 
                    }
                };
                await _context.DailyActivity.AddAsync(activity);
            }
            
            _context.SaveChanges();
            return Ok(foodReport);
        }
    }
}
