using Catalog.Domain;

namespace Catalog.Application.Contracts.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {

        //Her entity'nin karşılığı olan db tablosunda yapılacak ortak eylemler.
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
