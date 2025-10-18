using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLABSITI.Models
{
    public class Student
    {
        [Key]
        public int SSN { get; set;}
        public string Name { get; set;}
        public int Age { get; set;}
        public string? Address { get; set;}
        public string? Image { get; set; }
        public string? Email { get; set; }

        [ForeignKey(nameof(Department))]
        [Display(Name = "Department")]
        public int? DeptId { get; set;}
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set;} = new HashSet<Enrollment>();


    }
}
