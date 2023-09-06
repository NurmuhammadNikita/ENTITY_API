using Domain.Models;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductRepository
    {
        public Task CreateProductAsync(ProductDto product);
        public Task<Product> GetProductByIdAsync(Guid productId);
        public Task<List<Product>> GetAllAsync();
        public Task UpdateProductAsync(Guid ProductId, ProductDto ProductDto);
        public Task DeleteProductAsync(Guid ProductId);
    }
}
