using Catalog.Application.Contracts.Repositories;
using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> _products = new()
        {
            new() { Id=1, Name="Ürün A", Description="Açıklama A", ImageUrl="Resim A", Price=1},
            new() { Id=2, Name="Ürün B", Description="Açıklama B", ImageUrl="Resim B", Price=1},
            new() { Id=3, Name="Ürün C", Description="Açıklama C", ImageUrl="Resim C", Price=1},

        };



        public Task CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
          return   await Task.FromResult(this._products);
        }

        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
