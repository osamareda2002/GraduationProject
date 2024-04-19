using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    //[PrimaryKey(nameof(TraineeId), nameof(Sport), nameof(DateOfOccurrence))]
    public class SportReport
    {
        [Key]
        public int ReportId { get; set; }
        public int TraineeId { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public int sportId { get; set; }
        public double DurationTime { get; set; }

    }
}
