
namespace Org.Library
{
    public interface IRepository<T>
    {
        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        T Get(object identity);
    }
}
