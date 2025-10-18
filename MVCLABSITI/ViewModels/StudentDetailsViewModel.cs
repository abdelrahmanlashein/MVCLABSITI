using MVCLABSITI.Models;

namespace MVCLABSITI.ViewModels
{
    public class StudentDetailsViewModel
    {
       public int StudentId { get; set; }
       public string StudentName { get; set; }
       public string DepartmentName { get; set; }
       public List<Enrollment> Enrollments { get; set; } = new();
    }
}
