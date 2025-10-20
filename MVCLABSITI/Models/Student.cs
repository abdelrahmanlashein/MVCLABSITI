using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLABSITI.Models
{
    public class Student
    {
        [Key]
        public int SSN { get; set;}
        [RegularExpression("[a-zA-Z]{5,20}", ErrorMessage = "must be only letters btw [5,20]")]
        public string Name { get; set;}
        [Range(21,30, ErrorMessage = "Age must be btw [21:30]")]
        public int Age { get; set;}
        [RegularExpression("[a-zA-Z]{3,50", ErrorMessage = "must be only letters btw [3,50]")]
        public string? Address { get; set;}
        public string? Image { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [ForeignKey(nameof(Department))]
        [Display(Name = "Department")]
        public int? DeptId { get; set;}
        public Department? Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set;} = new HashSet<Enrollment>();


    }
}
