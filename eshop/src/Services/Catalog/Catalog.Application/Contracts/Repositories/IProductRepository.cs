using Catalog.Domain;

namespace Catalog.Application.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchByName(string name);
        Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
    }
}
