using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCLABSITI.Models;

namespace MVCLABSITI.Context
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.SSN, e.CourseId });

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(ca => new { ca.InsId, ca.CourseId });
        }
    }
}