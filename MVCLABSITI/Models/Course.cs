using System.ComponentModel.DataAnnotations;

namespace MVCLABSITI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Degree { get; set; }
        public string MinDegree { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<CourseAssignment> CourseAssignments { get; set; } = new HashSet<CourseAssignment>();
    }
}
