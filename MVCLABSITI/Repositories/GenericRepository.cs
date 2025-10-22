using Microsoft.EntityFrameworkCore;
using MVCLABSITI.Context;

namespace MVCLABSITI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SchoolContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(SchoolContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

       

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public string? GetByCondition(Func<object, bool> value)
        {
            var result = _dbSet.AsEnumerable().FirstOrDefault(value);
            return result?.ToString();
        }
    }
}
