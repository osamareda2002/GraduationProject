using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    //[PrimaryKey(nameof(TraineeId),nameof(Food),nameof(DateOfOccurrence))]
    public class FoodReport
    {
        [Key]
        public int ReportId { get; set; }
        public int TraineeId { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public int foodId { get; set; }
        public double quantity { get; set; }


    }

}
