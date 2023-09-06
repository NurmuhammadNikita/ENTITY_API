using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

namespace ENTITY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository productTypeRepository;

        public ProductTypeController(IProductTypeRepository productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository;
        }

        [HttpPost]
        //Create uchun

        public async Task<IActionResult> CreateProductType([FromForm] ProductTypeDto ProductTypeDto)
        {
            await productTypeRepository.CreateProductTypeAsync(ProductTypeDto );

            return Ok("Created");
        }




        [HttpGet("companyid")]
        public async Task<IActionResult> GetProductTypeId (Guid productTypeId )
        {
            var product = await productTypeRepository.GetProductTypeByIdAsync(productTypeId);
            return Ok(product);
        }




        [HttpGet]

        public async Task<IActionResult> GetAllClents()
        {
            var products = await productTypeRepository.GetAllAsync();

            return Ok(products);
        }




        [HttpPut("roductTypeId ")]
        public async Task<IActionResult> GetProductId(Guid productId, [FromForm] ProductTypeDto  productTypeDto )
        {
            await productTypeRepository.UpdateProductTypeAsync(productId, productTypeDto );
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid productTypeId )
        {
            await productTypeRepository.DeleteProductTypeAsync(productTypeId );

            return Ok("Deleted");
        }
    }
}
