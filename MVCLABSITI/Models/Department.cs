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
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Location { get; set; }
        public Branches Branch { get; set; }

        public ICollection<Student> Students  { get; set; } = new HashSet<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
