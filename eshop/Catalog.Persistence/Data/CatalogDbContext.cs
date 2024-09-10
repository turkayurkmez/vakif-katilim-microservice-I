using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Persistence.Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Kategori 1" },
                new Category { Id = 2, Name = "Kategori 2" }

                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Ürün 1",
                    Description = "Açıklama Ürün 1",
                    CategoryId = 1,
                    ImageUrl = "url 1",
                    Price = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Ürün 2",
                    Description = "Açıklama Ürün 2",
                    CategoryId = 2,
                    ImageUrl = "url 34",
                    Price = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Ürün 3",
                    Description = "Açıklama Ürün 3",
                    CategoryId = 1,
                    ImageUrl = "url 3",
                    Price = 1
                }
            );


        }

    }
}
