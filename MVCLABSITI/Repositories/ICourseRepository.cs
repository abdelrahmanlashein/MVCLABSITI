using MVCLABSITI.Models;

namespace MVCLABSITI.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Course DetailsVM (int id);
    }
}
