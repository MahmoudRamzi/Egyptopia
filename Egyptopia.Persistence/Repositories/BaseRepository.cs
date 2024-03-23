using Egyptopia.Application.Repositories;
using Egyptopia.Persistence.Context;

namespace Egyptopia.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        T? IBaseRepository<T>.Create(T entity)
        {
            var data = _dataContext.Add(entity).Entity;
            _dataContext.SaveChanges();
            return data;
        }

        void IBaseRepository<T>.Delete(T entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        T? IBaseRepository<T>.Get(Guid id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        List<T>? IBaseRepository<T>.GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        T? IBaseRepository<T>.Update(T entity)
        {
            var data = _dataContext.Update(entity).Entity;
            _dataContext.SaveChanges();
            return data;
        }
    }
}