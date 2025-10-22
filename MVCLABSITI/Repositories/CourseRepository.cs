using Microsoft.EntityFrameworkCore;
using MVCLABSITI.Context;
using MVCLABSITI.Models;

namespace MVCLABSITI.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly SchoolContext _context;
        public CourseRepository(SchoolContext context) : base(context)
        {
            _context = context;
        }
        public Course DetailsVM(int id)
        {
            return _context.Courses
                .Include(c => c.CourseAssignments)
                .ThenInclude(ca => ca.Instructor)
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .FirstOrDefault(c => c.CourseId == id);
        }
    }
}
