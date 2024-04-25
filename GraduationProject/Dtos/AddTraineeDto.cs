using GraduationProject.Models;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Dtos
{
    public class AddTraineeDto
    {
        public string? Name { get; set; } = string.Empty;
        //public string? LastName { get; set; } = string.Empty;
        public string? Gmail { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public string? Purpose { get; set; } = string.Empty;
        //public bool HasTools { get; set; } = false;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Range(55, 274)]
        public int? Height { get; set; } = 55;
        [Range(30, 635)]
        public int? Weight { get; set; } = 30;
        public string? FitnessLevel { get; set; } = string.Empty;
        public int? RequiredCalories { get; set; } = 1200;
        public List<int>? AvailabaleDays { get; set; } = new List<int>();
        public List<int>? TraineeSports { get; set; } = new List<int>();
        public List<int>? TraineeFoods { get; set; } = new List<int>();
    }
}
