using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLABSITI.Models
{
    public enum Branches
    {
        Alex,
        Cairo,
        Fym
    }
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [RegularExpression("[a-zA-Z]{3,25}",ErrorMessage = "must be only letters btw [3,20]")]    //remot validation
        public string? Name { get; set; }
        [RegularExpression("[a-zA-Z]{3,20}",ErrorMessage = "must be only letters btw [3,20]")]
        public string? ManagerName { get; set; }
        [MinLength(3, ErrorMessage = "Name must btw 3:50"), MaxLength(50, ErrorMessage = "Name must btw 3:50")]
        public string? Location { get; set; }
        [MinLength(3, ErrorMessage = "Name must btw 3:15"), MaxLength(15, ErrorMessage = "Name must btw 3:15")]
        public Branches Branch { get; set; }

        public ICollection<Student> Students  { get; set; } = new HashSet<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
