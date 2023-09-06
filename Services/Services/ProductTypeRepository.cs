using Domain.Models;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductTypeRepository : IProductTypeRepository
    {

        private readonly MarketDB marketDB;

        public ProductTypeRepository(MarketDB marketDB)
        {
            this.marketDB = marketDB;
        }


        public async Task CreateProductTypeAsync(ProductTypeDto productType)
        {
            var producttype = new ProductType
            {
                Id = Guid.NewGuid(),
                Name = productType.Name,
            };

            await marketDB.ProductTypes.AddAsync(producttype);
            await marketDB.SaveChangesAsync();

        }

        public async Task DeleteProductTypeAsync(Guid productTypeId)
        {
            var producttype = await marketDB.ProductTypes.FirstOrDefaultAsync(c=> c.Id == productTypeId);

             marketDB.ProductTypes.Remove(producttype);
            await marketDB.SaveChangesAsync();
        }

        public async Task<List<ProductType>> GetAllAsync()
        {
            var producttype = await marketDB.ProductTypes.ToListAsync();
            return producttype;
        }

        public async Task<ProductType> GetProductTypeByIdAsync(Guid productTypeId)
        {
            var producttype = await marketDB.ProductTypes.FirstOrDefaultAsync(c => c.Id == productTypeId);

            return producttype;
        }

        public async Task UpdateProductTypeAsync(Guid productTypeId, ProductTypeDto productTypeDto)
        {
            var producttype = marketDB.ProductTypes.FirstOrDefault(c => c.Id == productTypeId);
            producttype.Name = productTypeDto.Name;

            marketDB.ProductTypes.Update(producttype);
            await marketDB.SaveChangesAsync();
        }
    }
}
