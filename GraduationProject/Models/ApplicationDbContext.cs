using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<FoodReport> FoodReports { get; set; }
        public DbSet<SportReport> SportReports { get; set; }
        public DbSet<DailyActivity> DailyActivity { get; set; }
        public DbSet<FoodEaten> FoodEatens { get; set; }
        public DbSet<SportDone> SportDones { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<Breakfast> Breakfasts { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<AfterWorkMeal> AfterWorkMeals { get; set; }

    }
}
