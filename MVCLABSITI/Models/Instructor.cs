using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLABSITI.Models
{
    public class Instructor
    {
        [Key]
        public int InsId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Image { get; set; }
        public DateTime HiringDate { get; set; }
        public string Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseAssignment> CourseAssignmesnts { get; set; } = new HashSet<CourseAssignment>();

    }
}
