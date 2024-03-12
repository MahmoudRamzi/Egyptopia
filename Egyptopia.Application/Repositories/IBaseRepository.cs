namespace Egyptopia.Application.Repositories
{

    public interface IBaseRepository<T> where T : class
    {
        T? Create(T entity);
        T? Update(T entity);
        void Delete(Guid id);
        T? Get(Guid id);
        List<T>? GetAll();
    }
}
