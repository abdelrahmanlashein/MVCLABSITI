using Microsoft.AspNetCore.Mvc;
using MVCLABSITI.Validators;
using System.ComponentModel.DataAnnotations;

namespace MVCLABSITI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Remote("UniqueName","Course","Course already exist")]
        public string Name { get; set; }
        [MinLength(3, ErrorMessage = "Name must btw 3:50"), MaxLength (50, ErrorMessage = "Name must btw 3:50")]
        public string Topic { get; set; }
        [Range(100,100, ErrorMessage =" degree must be  100")]
        public string Degree { get; set; }
        [Range(60, 60, ErrorMessage = " MinDegree must be  60")]

        public string MinDegree { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<CourseAssignment> CourseAssignments { get; set; } = new HashSet<CourseAssignment>();
    }
}
