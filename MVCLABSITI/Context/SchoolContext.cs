using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCLABSITI.Models;

namespace MVCLABSITI.Context
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolDb;Integrated Security=True;Trust Server Certificate=True;");
        }
        public DbSet<Student> Students { get; set;}
    }  
}
