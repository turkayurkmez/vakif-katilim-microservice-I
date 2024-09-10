using Catalog.Application.Contracts.Repositories;
using Catalog.Domain;
using Catalog.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Repositories
{
    public class ProductRepository(CatalogDbContext catalogDbContext) : IProductRepository
    {
        public async Task CreateAsync(Product entity)
        {
            catalogDbContext.Products.Add(entity);
            await catalogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await catalogDbContext.Products.FindAsync(id);
            catalogDbContext.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await catalogDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await catalogDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await catalogDbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByName(string name)
        {
            return await catalogDbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            catalogDbContext.Products.Update(entity);
            await catalogDbContext.SaveChangesAsync();

        }
    }
}
