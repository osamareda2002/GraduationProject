using GraduationProject.Models;

namespace GraduationProject.Dtos
{
    public class AddSportReport
    {
        public int TraineeId { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public int sportId { get; set; }
        public double DurationTime { get; set; }

    }
}
