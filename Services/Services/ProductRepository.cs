using Domain.Models;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductRepository : IProductRepository
    {
        
        
            private readonly MarketDB marketDB;

            public ProductRepository(MarketDB marketDB)
            {
                this.marketDB = marketDB;
            }

       

        public async Task CreateProductAsync(ProductDto product)
            {
                var createProduct = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = product.Name,
                    TypeId = product.TypeId,
                    DateMonifacture = product.DateMonifacture,
                    DateExpiration = product.DateExpiration,
                    

                };

                await marketDB.Products.AddAsync(createProduct);
                await marketDB.SaveChangesAsync();
            }

            public async Task DeleteProductAsync(Guid productId)
            {
                var deleteProduct = await marketDB.Products.FirstOrDefaultAsync(c => c.Id == productId);

                marketDB.Products.Remove(deleteProduct);
                marketDB.SaveChanges();
            }

            public async Task<List<Product>> GetAllAsync()
            {
                var products = await marketDB.Products.ToListAsync();
                return products;
            }

            public async Task<Product> GetProductByIdAsync(Guid productId)
            {
                var product = await marketDB.Products.FirstOrDefaultAsync(c => c.Id == productId);

                return product;
            }

            public async Task UpdateProductAsync(Guid productId, ProductDto productDto)
            {
                var product = await marketDB.Products.FirstOrDefaultAsync(c => c.Id == productId);
                
                product.Name = productDto.Name;
                product.TypeId = productDto.TypeId;
                product.DateMonifacture = productDto.DateMonifacture;
                product.DateExpiration = productDto.DateExpiration;

                marketDB.Products.Update(product);

                marketDB.SaveChanges();


            }
        }
}
