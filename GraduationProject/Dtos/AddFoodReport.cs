using GraduationProject.Models;

namespace GraduationProject.Dtos
{
    public class AddFoodReport
    {
        public int TraineeId { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public int foodId { get; set; }
        public double quantity { get; set; }
    }
}
