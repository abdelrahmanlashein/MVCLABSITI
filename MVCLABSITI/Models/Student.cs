using System.ComponentModel.DataAnnotations;

namespace MVCLABSITI.Models
{
    public class Student
    {
        [Key]
        public int Ssn { get; set;}
        public string Name { get; set;}
        public int Age { get; set;}
        public string? Address { get; set;}
        public string? Image { get; set; }
        public string? Email { get; set; }

    }
}
