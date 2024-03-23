namespace Egyptopia.Application.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T? Create(T entity);

        T? Update(T entity);

        void Delete(T entity);

        T? Get(Guid id);

        List<T>? GetAll();
    }
}