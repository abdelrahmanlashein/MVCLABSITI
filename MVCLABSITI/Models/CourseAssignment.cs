using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLABSITI.Models
{
    public class CourseAssignment
    {
        public int RateHoure { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InsId { get; set; }
        public Instructor Instructor { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
