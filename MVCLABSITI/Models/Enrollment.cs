using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLABSITI.Models
{
    public class Enrollment
    {
        [Range(0,100, ErrorMessage = "Grade must be btw [0:100]")]
        public decimal Grade { get; set;}

        [ForeignKey(nameof(Student))]
        public int SSN { get; set; }
        public Student Student { get; set;}


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }



    }
}
