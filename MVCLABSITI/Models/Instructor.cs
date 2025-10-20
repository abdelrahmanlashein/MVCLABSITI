using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLABSITI.Models
{
    public class Instructor
    {
        [Key]
        public int InsId { get; set; }
        [RegularExpression("[a-zA-Z]{2,25}", ErrorMessage = "must be only letters btw [2,25]")]
        public string Name { get; set; }
        [Range(25,50, ErrorMessage = "Age must be btw [25:50]")]
        public int Age { get; set; }
        [Range(25000,70000, ErrorMessage = "Salary must be btw [25000:70000]")]
        public decimal Salary { get; set; }
        public string Image { get; set; }
        public DateTime HiringDate { get; set; }
        [RegularExpression("[a-zA-Z]{3,50}", ErrorMessage = "must be only letters btw [3,50]")]
        public string Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseAssignment> CourseAssignmesnts { get; set; } = new HashSet<CourseAssignment>();

    }
}
