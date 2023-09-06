using Domain.Models;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductTypeRepository
    {
        public Task CreateProductTypeAsync(ProductTypeDto productType);
        public Task<ProductType> GetProductTypeByIdAsync(Guid productTypeId);
        public Task<List<ProductType>> GetAllAsync();
        public Task UpdateProductTypeAsync(Guid productTypeId, ProductTypeDto productTypeDto);
        public Task DeleteProductTypeAsync(Guid productTypeId);
    }
}
